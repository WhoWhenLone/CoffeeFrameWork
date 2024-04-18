using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BuildBundle
{
    [MenuItem("Build/BuildBundle")]
    public static void BuildAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.ForceRebuildAssetBundle, BuildTarget.StandaloneWindows);
    }
    
    [MenuItem("Build/BuildBundle_Atlas")]
    public static void BuildAssetBundle_Atlas()
    {
        var spriteList = new string[]
        {
            // "Assets/GameAssets/Sprites/Test/1.png",
            // "Assets/GameAssets/Sprites/Test/2.png",
            // "Assets/GameAssets/Sprites/Test/3.png",
            "Assets/GameAssets/Sprites/Test/atlas/test.spriteatlas",
        };

        var dependencies = AssetDatabase.GetDependencies("Assets/GameAssets/Sprites/Test/atlas/test.spriteatlas");
        var assetNameList = new List<string>();
        for (int i = 0; i < dependencies.Length; i++)
        {
            assetNameList.Add(dependencies[i]);
        }
        var buildBundle = new AssetBundleBuild()
        {
            assetBundleName = "sprite_atlas",
            assetNames = assetNameList.ToArray(),
        };

        var buildList = new AssetBundleBuild[]
        {
            buildBundle
        };
        BuildPipeline.BuildAssetBundles(Application.dataPath + "/AssetBundles", buildList, BuildAssetBundleOptions.ChunkBasedCompression | BuildAssetBundleOptions.ForceRebuildAssetBundle | BuildAssetBundleOptions.DisableWriteTypeTree, BuildTarget.StandaloneWindows);
    }
}
