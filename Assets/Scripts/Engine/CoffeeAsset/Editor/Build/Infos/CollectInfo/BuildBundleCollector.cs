// BuildBundleCollector.cs
// Created by nancheng.
// DateTime: 2024年8月13日 18:00:51
// Desc: 

using System.Collections.Generic;
using UnityEditor;

namespace CoffeeAsset.Build.CollectInfo
{
    public class BuildBundleCollector
    {
        public List<CollectBundleInfo> CollectBundleInfos()
        {
            var list = new List<CollectBundleInfo>();
            var allPackGroups = GetPackGroups();
            foreach (var group in allPackGroups)
            {
                list.AddRange(group.CollectBundleInfos());
            }

            return list;
        }

        private List<BuildGroup> GetPackGroups()
        {
            var list = new List<BuildGroup>();

            var assetConfig = AssetDatabase.LoadAssetAtPath<CoffeeAssetConfig>(BuildSetting.AssetConfigPath);
            if (assetConfig != null)
            {
                list.AddRange(assetConfig.BuildGroups);
            }
            
            return list;
        }
    }
}