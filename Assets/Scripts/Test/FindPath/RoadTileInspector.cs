using UnityEditor;
using UnityEngine;

namespace CoffeeFrameWork.FindPath
{
    [CustomEditor(typeof(RoadTile))]
    public class RoadTileInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            RoadTile tile = (RoadTile)target;
    
            DrawDefaultInspector();
    
            tile.RoadType = (RoadType)EditorGUILayout.EnumPopup("RoadType", tile.RoadType);
    
            if (GUI.changed)
            {
                EditorUtility.SetDirty(tile);
            }
        }
    }
}