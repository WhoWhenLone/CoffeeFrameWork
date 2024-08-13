// Task_CreateManifest.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:53
// Desc: 生成资源清单

using System.Collections.Generic;
using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_CreateAssetFile : IBuildTask
    {
        public void Run(BuildContext context)
        {
            var buildResultContext = context.GetContextObject<BuildResultContext>();
            var unityManifest = buildResultContext.UnityManifest;

            var bundleMap = new Dictionary<string, BuildBundleInfo>();
            
            AssetLogHelper.Log("Task_CreateManifest");
        }
    }
}