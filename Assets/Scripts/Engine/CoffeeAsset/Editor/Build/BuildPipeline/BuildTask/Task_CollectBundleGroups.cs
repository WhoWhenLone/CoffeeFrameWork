// Task_CollectBundleGroups.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:08
// Desc: 收集BuildBundle信息

using System.Collections.Generic;
using System.Linq;
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
            // 收集到的所有资源info
            var buildAssetMap = new Dictionary<string, AssetInfo>();
            // 当前主资源依赖的资源引用信息
            var allDepInfosByMain = new Dictionary<string, int>();

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

                        if (collectInfo.PackAssetType == PackAssetType.MainAsset)
                        {
                            var dependAssets = AssetDatabase.GetDependencies(assetInfo.AssetPath);
                            foreach (var depAssetPath in dependAssets)
                            {
                                if (allDepInfosByMain.ContainsKey(depAssetPath))
                                {
                                    allDepInfosByMain[depAssetPath]++;
                                }
                                else
                                {
                                    allDepInfosByMain[depAssetPath] = 1;
                                }
                            }
                        }
                    }
                }
            }
            
            // 获取打包配置中收集出来的当前所有依赖类型的资源
            // 获取当前主资源及所有依赖资源
            // 收集出来的依赖，在主资源及依赖里 才真正打包
            
            // 方案1 根据pack 设置 收集到所有的资源，然后根据主资源的依赖的资源，剔除收集到的依赖的资源，得到所有需要打包的资源
            // 方案2 根据pack 设置 收集所有的主资源，然后分析所有依赖的资源，设置依赖的bundle，额外的操作太多了
            
            // 方案2 额外的操作太多了，依赖的资源 bundle名字怎么取，跟着谁，common一般都是依赖的，应该单独的规则
            // 结论 明确的表示依赖的资源 怎么处理 收集到所有资源后，在过滤一下依赖资源，去掉引用为0的

            var toRemovePaths = new List<string>();
            foreach (var keyValue in buildAssetMap)
            {
                if (keyValue.Value.PackAssetType == PackAssetType.DependAsset && !allDepInfosByMain.ContainsKey(keyValue.Key))
                {
                    toRemovePaths.Add(keyValue.Key);
                }
            }

            foreach (var path in toRemovePaths)
            {
                buildAssetMap.Remove(path);
            }
            
            foreach (var assetInfo in buildAssetMap.Values)
            {
                buildMapContext.PackAsset(assetInfo);
            }
            
            AssetLogHelper.Log("Task_CollectBundleGroups");
        }
    }
}