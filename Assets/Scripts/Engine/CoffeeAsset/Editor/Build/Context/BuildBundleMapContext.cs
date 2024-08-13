// BuildBundleMapContext.cs
// Created by nancheng.
// DateTime: 2024年8月13日 16:59:03
// Desc: 构建的Bundle的数据上下文

using System;
using System.Collections.Generic;
using UnityEditor;

namespace CoffeeAsset.Build
{
    public class BuildBundleMapContext : IContextObject
    {
        private readonly Dictionary<string, BuildBundleInfo>
            _buildBundleMap = new Dictionary<string, BuildBundleInfo>();

        public void PackAsset(AssetInfo assetInfo)
        {
            var abName = assetInfo.BelongAbName;
            if (string.IsNullOrEmpty(abName))
            {
                throw new Exception("abName must have");
            }
            
            if (_buildBundleMap.TryGetValue(abName, out var buildBundleInfo))
            {
                buildBundleInfo.PackAsset(assetInfo);
            }
            else
            {
                var newBundleInfo = new BuildBundleInfo(abName);
                newBundleInfo.PackAsset(assetInfo);
                _buildBundleMap.Add(abName, newBundleInfo);
            }
        }

        public AssetBundleBuild[] GetAllBundleBuilds()
        {
            List<AssetBundleBuild> list = new List<AssetBundleBuild>();
            foreach (var buildBundleInfo in _buildBundleMap)
            {
                list.Add(buildBundleInfo.Value.CreateBundleBuild());
            }

            return list.ToArray();
        }
    }
}