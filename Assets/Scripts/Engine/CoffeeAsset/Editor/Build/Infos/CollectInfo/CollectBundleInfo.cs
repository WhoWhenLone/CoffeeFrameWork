// CollectBundleInfo.cs
// Created by nancheng.
// DateTime: 2024年8月13日 17:54:34
// Desc: 

using System;
using System.Collections.Generic;
using UnityEditor.VersionControl;

namespace CoffeeAsset.Build.CollectInfo
{
    public class CollectBundleInfo
    {
        public string BundleName;

        public PackAssetType PackAssetType;
        
        public List<AssetInfo> AssetInfos;

        public CollectBundleInfo(string abName)
        {
            BundleName = abName;
            AssetInfos = new List<AssetInfo>();
        }
        
        public void CollectAsset(AssetInfo assetInfo)
        {
            if (AssetInfos.Contains(assetInfo))
            {
                throw new Exception("collect asset is exist");
            }
            
            AssetInfos.Add(assetInfo);
        }
    }
}