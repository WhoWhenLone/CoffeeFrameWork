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
            buildParam.AppVersion = "1.0.0";
            buildParam.AssetVersion = "1";
            buildParam.BuildMode = BuildMode.SimulateBuild;
            buildParam.FileNameStyle = FileNameStyle.FileName_Hash;
            
            BuildLauncher.ExecuteBuildBundle(buildParam);
        }
    }
}