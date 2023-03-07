using UnityEditor;
using UnityEngine;

namespace CoffeeEditor
{
    [InitializeOnLoad]
    public class TestHierarchy
    {
        static TestHierarchy()
        {
            //EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyGUI;
        }

        private static void OnHierarchyGUI(int instanceId, Rect selectionRect)
        {
            GameObject go  = EditorUtility.InstanceIDToObject(instanceId) as GameObject;
            if (go != null)
            {
                EditorGUI.LabelField(new Rect(selectionRect.x + 150, selectionRect.y, selectionRect.width, selectionRect.height), go.name);
            }
        }
    }
}