// Task_CreateBuildBundles.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:42
// Desc: 创建BuildBundle数据

using System;
using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_CreateBuildBundles : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_CreateBuildBundles");

            var buildMapContext = context.GetContextObject<BuildBundleMapContext>();
            var buildParamsContext = context.GetContextObject<BuildParamContext>();
            
            var bundleOutPutDir = buildParamsContext.Params.BuildOutputRoot;
            var buildOptions = buildParamsContext.Params.BuildOptions;
            var buildTarget = buildParamsContext.Params.BuildTarget;
            var bundleBuilds = buildMapContext.GetAllBundleBuilds();

            var unityManifest =
                UnityEditor.BuildPipeline.BuildAssetBundles(bundleOutPutDir, bundleBuilds, buildOptions, buildTarget);

            if (unityManifest == null)
            {
                throw new Exception("BuildAssetBundles Failed");
            }
            
            var buildResultContext = new BuildResultContext();
            context.AddContextObject(buildResultContext);
            buildResultContext.UnityManifest = unityManifest;
        }
    }
}