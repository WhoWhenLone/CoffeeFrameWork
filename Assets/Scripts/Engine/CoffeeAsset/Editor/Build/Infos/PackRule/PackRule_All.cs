// PackRule_All.cs
// Created by nancheng.
// DateTime: 2024年8月13日 15:23:43
// Desc: 

using System.Collections.Generic;
using System.IO;
using CoffeeAsset.Build.CollectInfo;
using CoffeeAsset.Utils;
using UnityEditor.VersionControl;

namespace CoffeeAsset.Build.PackRule
{
    public class PackRule_All : IPackRule
    {
        public List<CollectBundleInfo> GetBuildBundleInfo(BuildPackInfo packInfo)
        {
            var list = new List<CollectBundleInfo>();

            string abName = PathHelper.GetFileName(packInfo.AssetPath, false);
            var collectInfo = new CollectBundleInfo(abName);
            var files = FileHelper.GetAllFiles(packInfo.AssetPath, packInfo.SearchPattern, SearchOption.AllDirectories);
            foreach (var fileInfo in files)
            {
                if (!fileInfo.Name.EndsWith(".meta"))
                {
                    var filePath = PathHelper.FormatPath(fileInfo.ToString());
                    var assetInfo = new AssetInfo(filePath, abName);
                    
                    collectInfo.PackAssetType = packInfo.PackAssetType;
                    collectInfo.CollectAsset(assetInfo);
                }
            }
            list.Add(collectInfo);
            
            return list;
        }
    }
}