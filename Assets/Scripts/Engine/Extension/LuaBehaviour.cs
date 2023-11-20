using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using XLua;

namespace CoffeeFrameWork
{
    [Serializable]
    public class Injection
    {
        public string name;
#if ODIN_INSPECTOR
        [OnValueChanged("OnValueChange")]
        public GameObject gameObject;
        [ValueDropdown("GetComponents"), EnableIf("@this.gameObject")]
        public UnityEngine.Object component;
#else
        public GameObject gameObject;
        public UnityEngine.Object component;
#endif

        private void OnValueChange()
        {
            InitName();
        }

        private IEnumerable GetComponents()
        {
            if (gameObject != null)
            {
                var componments = gameObject.GetComponents<Component>();
                var list = new ValueDropdownList<UnityEngine.Object>();
                foreach (var componment in componments)
                {
                    list.Add(componment);
                }

                return list;
            }

            return null;
        }

        private void InitName()
        {
            if (gameObject != null && !string.IsNullOrEmpty(gameObject.name))
            {
                var nameChars = gameObject.name.ToCharArray();
                name = "_" + nameChars[0].ToString().ToLower();
                for (int i = 1; i < nameChars.Length; i++)
                {
                    name += nameChars[i];
                }
            }
            else
            {
                name = "";
            }
        }
    }
    
    public class LuaBehaviour : MonoBehaviour
    {
#if ODIN_INSPECTOR
        [SerializeField, Required("must input luaScripts name"), Tooltip("与UI组件保持命名一致")]
        private string m_LuaScriptName;
        [TableList]
        public Injection[] Injections;
#else
        public Injection[] Injections;
        [SerializeField]
        private string m_LuaScriptName;
#endif
        
        private readonly UnityEngine.Object m_Null = null;
        private LuaTable m_LuaTable;
        private bool m_IsInject;
        public void InjectToLuaTable(LuaTable luaTable)
        {
            if (luaTable == null || m_IsInject)
            {
                Debug.LogError("Inject Error");
                return;
            }
            
            m_LuaTable = luaTable;
            m_IsInject = true;
            if (Injections != null)
            {
                foreach (var injection in Injections)
                {
                    if (injection.gameObject != null)
                    {
                        m_LuaTable.Set(injection.name, injection.component);
                    }
                }
            }
        }

        public void RemoveFromLuaTable()
        {
            if (!m_IsInject || m_LuaTable == null || Injections == null)
            {
                return;
            }

            foreach (var injection in Injections)
            {
                if (!string.IsNullOrEmpty(injection.name))
                {
                    m_LuaTable.Set(injection.name, m_Null);
                }
            }

            m_IsInject = false;
            m_LuaTable = null;
        }

        private void OnDestroy()
        {
            RemoveFromLuaTable();
        }

#if UNITY_EDITOR
        [ContextMenu("生成lua成员构造器")]
        private void CopyLuaBehaviourToClip()
        {
            if (Injections != null && Injections.Length > 0)
            {
                string resultStr = "";
                resultStr = "\nfunction M:construct()\n";
                foreach (var injectInfo in Injections)
                {
                    if (injectInfo != null && injectInfo.gameObject != null)
                    {
                        resultStr += "self." + injectInfo.name + " = nil" + "\n";
                    }
                }

                resultStr += "end \n";
                Debug.LogError(GameDefines.LuaScriptsRoot);
                GUIUtility.systemCopyBuffer = resultStr;
            }
            else
            {
                EditorUtility.DisplayDialog("警告","属性列表为空，不可创建", "OK");
            }
        }
#endif
    }
}

