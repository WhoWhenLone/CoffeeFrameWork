using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace CoffeeEditor
{
    public class TestAssetDatabase : EditorWindow
    {
        private static string[] m_ResultFiles;
        
        [MenuItem("Assets/GetDependencies")]
        private static void GetDependencies()
        {
            string path = AssetDatabase.GetAssetPath(Selection.activeObject);
            m_ResultFiles = AssetDatabase.GetDependencies(path);
            var window = GetWindow<TestAssetDatabase>();
            if (window != null)
            {
                window.titleContent = new GUIContent("依赖信息");
                window.Show();
            }
        }

        void OnGUI()
        {
            GUILayout.Label(Selection.activeObject.name + "的依赖信息");
            // if (m_ResultFiles != null && m_ResultFiles.Length > 0)
            // {
            //     GUILayout.BeginScrollView();
            // }
            // GUILayout.BeginVertical();
            //
            // GUILayout.EndVertical();
            
            GUILayout.BeginScrollView(new Vector2(0, 0));
            
            for (int i = 0; i < m_ResultFiles.Length; i++)
            {
                GUILayout.BeginHorizontal();
                GUILayout.Label("依赖: " + i);
                GUILayout.Width(50f);
                GUILayout.Label(m_ResultFiles[i]);
                if(GUILayout.Button("打印"))
                {
                    Debug.Log(m_ResultFiles[i]);
                }
                GUILayout.EndHorizontal();
            }
            GUILayout.EndScrollView();
        }
    } 
}

