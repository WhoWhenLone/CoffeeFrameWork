// BuildAssetInfo.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:21:23
// Desc: 

using System;
using System.Collections.Generic;
using System.Linq;

namespace CoffeeAsset.Build
{
    public class BuildAssetInfo
    {
        /// <summary>
        /// Bundle名称
        /// </summary>
        public string BundleName;

        /// <summary>
        /// bundle所包含的资源
        /// </summary>
        public List<AssetInfo> AssetInfos = new List<AssetInfo>();

        public void AddAsset(string path)
        {
            if (IsContainAsset(path))
            {
                throw new Exception($"Asset is existed = {path}");
            }
            // var assetInfo = new AssetInfo()
            // {
            //     AssetPath = path,
            //     AssetGUID = 
            // }
        }

        private bool IsContainAsset(AssetInfo assetInfo)
        {

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