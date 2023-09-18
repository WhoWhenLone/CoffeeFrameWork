using System;
using UnityEditor;
using UnityEngine;

namespace CoffeeEditor
{
    public class TestEditorWindow : EditorWindow
    {
        [MenuItem("Tools/TestEditorWindow")]
        private static void ShowWindow()
        {
            var window = GetWindow<TestEditorWindow>();
            if (window != null)
            {
                window.titleContent = new GUIContent("TestEditorWindow");
                window.Show();
            }
        }

        private void OnGUI()
        {
            // GUILayout.BeginVertical();
            // GUILayout.BeginHorizontal();
            // GUILayout.Label("测试水平排列");
            // if(GUILayout.Button("测试按钮1"))
            // {
            //     EditorUtility.DisplayDialog("title", "测试按钮1", "OK");
            // }
            //
            // if(GUILayout.Button("测试按钮2"))
            // {
            //     EditorUtility.DisplayDialog("title", "测试按钮2", "OK");
            // }
            //
            // GUILayout.EndHorizontal();
            //
            // GUILayout.Label("选择Prefab资源");
            // GameObject go;
            // GUILayout.EndVertical();
            GUILayout.Label("窗口");
        }

        private void OnClick1()
        {
            
        }
        
    }
}