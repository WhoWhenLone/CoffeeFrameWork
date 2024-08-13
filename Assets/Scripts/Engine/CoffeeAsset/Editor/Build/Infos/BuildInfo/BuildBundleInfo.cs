// BuildBundleInfo.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:21:23
// Desc: 

using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeAsset.Build
{
    public class BuildBundleInfo
    {
        /// <summary>
        /// Bundle名称
        /// </summary>
        public string BundleName;

        /// <summary>
        /// bundle所包含的资源
        /// </summary>
        public List<AssetInfo> AssetInfos = new List<AssetInfo>();

        // 捞到所有要打包的文件
        // 捞到这些文件所有的依赖的文件
        // 怎么剔除这些文件里 没有用到资源

        public BuildBundleInfo(string abName)
        {
            BundleName = abName;
        }
        
        public void PackAsset(AssetInfo assetInfo)
        {
            if (IsContainAsset(assetInfo))
            {
                throw new Exception($"Asset is existed = {assetInfo.AssetPath}");
            }
            
            AssetInfos.Add(assetInfo);
        }

        private bool IsContainAsset(AssetInfo assetInfo)
        {
            foreach (var temp in AssetInfos)
            {
                if (assetInfo.AssetPath == temp.AssetPath)
                {
                    return true;
                }
            }
            return false;
        }
        
        public UnityEditor.AssetBundleBuild CreateBundleBuild()
        {  
            var bundleBuild = new UnityEditor.AssetBundleBuild()
            {
                assetBundleName = BundleName,
                assetNames = GetAssetNames(),
            };

            return bundleBuild;
        }

        private string[] GetAssetNames()
        {
            return AssetInfos.Select(t => t.AssetPath).ToArray();
        }
    }
}