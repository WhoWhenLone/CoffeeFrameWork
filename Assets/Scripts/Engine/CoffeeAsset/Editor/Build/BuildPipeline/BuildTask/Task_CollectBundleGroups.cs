// Task_CollectBundleGroups.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:08
// Desc: 收集BuildBundle信息

using System.Collections.Generic;
using CoffeeAsset.Build.CollectInfo;
using CoffeeAsset.Utils;
using UnityEditor;

namespace CoffeeAsset.Build
{
    public class Task_CollectBundleGroups : IBuildTask
    {
        public void Run(BuildContext context)
        {
            // 创建BuildMapContext 用于存储BuildBundleInfo数据
            // 获取所有的BuildGroup 然后收集BuildBundleInfo数据
            // 剔除无用的BuildAssetInfo
            // 将实际用到的BuildBundleInfo 添加到Context中

            // 整体的思路就是收集到所有的 资源路径，然后分配上bundle名称
            // 在过滤一下所有的资源路径，剔除掉没有引用的依赖的资源的路径
            // 剩下的就是所有要构建的资源路径
            // 创建构建Bundle信息
            
            var buildMapContext = new BuildBundleMapContext();
            context.AddContextObject(buildMapContext);
            
            var buildBundleCollector = new BuildBundleCollector();
            List<CollectBundleInfo> collectBundleInfoList = buildBundleCollector.CollectBundleInfos();
            var buildAssetMap = new Dictionary<string, AssetInfo>();
            
            foreach (var collectInfo in collectBundleInfoList)
            {
                foreach (var assetInfo in collectInfo.AssetInfos)
                {
                    if (buildAssetMap.ContainsKey(assetInfo.AssetPath))
                    {
                        AssetLogHelper.Log($"asset Path 重复了 path = {assetInfo.AssetPath}");
                    }
                    else
                    {
                        buildAssetMap.Add(assetInfo.AssetPath, assetInfo);
                    }
                }
            }
            
            // 获取打包配置中收集出来的当前所有依赖类型的资源
            // 获取当前主资源及所有依赖资源
            // 收集出来的依赖，在主资源及依赖里 才真正打包
            
            // 当前用到的资源信息
            // var allUseAssetInfos = new Dictionary<string, AssetInfo>();
            //
            // foreach (var collectInfo in collectBundleInfoList)
            // {
            //     if (collectInfo.PackAssetType == PackAssetType.MainAsset)
            //     {
            //         foreach (var assetInfo in collectInfo.AssetInfos)
            //         {
            //             allUseAssetInfos.Add(assetInfo.AssetPath, assetInfo);
            //             var dependAssets = AssetDatabase.GetDependencies(assetInfo.AssetPath);
            //             foreach (var denpend in dependAssets)
            //             {
            //                 allUseAssetInfos.Add(denpend, buildAssetMap[denpend]);                            
            //             }
            //         }
            //     }
            // }

            foreach (var assetInfo in buildAssetMap.Values)
            {
                buildMapContext.PackAsset(assetInfo);
            }
            
            AssetLogHelper.Log("Task_CollectBundleGroups");
        }
    }
}