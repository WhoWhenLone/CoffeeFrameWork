// PackRule_Single.cs
// Created by nancheng.
// DateTime: 2024年8月13日 15:21:54
// Desc: 

using System.Collections.Generic;
using System.IO;
using CoffeeAsset.Build.CollectInfo;
using CoffeeAsset.Utils;

namespace CoffeeAsset.Build.PackRule
{
    public class PackRule_Single : IPackRule
    {
        public List<CollectBundleInfo> GetBuildBundleInfo(BuildPackInfo packInfo)
        {
            var list = new List<CollectBundleInfo>();
            var path = packInfo.AssetPath;
            var files = FileHelper.GetAllFiles(path, packInfo.SearchPattern, SearchOption.AllDirectories);
            foreach (var fileInfo in files)
            {
                if (!fileInfo.Name.EndsWith(".meta"))
                {
                    var assetPath = PathHelper.FormatPath(fileInfo.ToString());
                    var abName = FileHelper.GetAbName(assetPath);
                    var assetInfo = new AssetInfo(assetPath, abName);
                    
                    var collectInfo = new CollectBundleInfo(assetPath);
                    collectInfo.PackAssetType = packInfo.PackAssetType;
                    collectInfo.CollectAsset(assetInfo);
                    
                    list.Add(collectInfo);
                }
            }
            return list;
        }
    }
}