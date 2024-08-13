// BuildMenus.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:05:02
// Desc: 

using UnityEditor;

namespace CoffeeAsset.Build.GUI
{
    public class BuildMenus
    {
        [MenuItem("CoffeeAsset/BuildBundle")]
        public static void BuildBundle()
        {
            var buildParam = new BuildParams();
            var assetCfg = AssetDatabase.LoadAssetAtPath<CoffeeAssetConfig>(BuildSetting.AssetConfigPath);
            buildParam.AppVersion = assetCfg.AppVersion;
            buildParam.AssetVersion = assetCfg.ResVersion;
            buildParam.BuildMode = BuildMode.SimulateBuild;
            buildParam.FileNameStyle = FileNameStyle.FileName_Hash;
            buildParam.BuildOutputRoot = assetCfg.OutputPath;
            
            BuildLauncher.ExecuteBuildBundle(buildParam);
        }
    }
}