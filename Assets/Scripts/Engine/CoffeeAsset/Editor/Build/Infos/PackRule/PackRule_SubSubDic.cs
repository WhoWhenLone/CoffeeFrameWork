// PackRule_SubSubDic.cs
// Created by nancheng.
// DateTime: 2024年8月13日 15:23:17
// Desc: 子文件夹的子文件夹打成1个

using System.Collections.Generic;
using System.IO;
using CoffeeAsset.Build.CollectInfo;
using CoffeeAsset.Utils;

namespace CoffeeAsset.Build.PackRule
{
    public class PackRule_SubSubDic : IPackRule
    {
        public List<CollectBundleInfo> GetBuildBundleInfo(BuildPackInfo packInfo)
        {
            var list = new List<CollectBundleInfo>();
            var subFiles = FileHelper.GetAllFiles(packInfo.AssetPath, packInfo.SearchPattern,
                SearchOption.TopDirectoryOnly);
            foreach (var subFileInfo in subFiles)
            {
                var subSubFiles = FileHelper.GetAllFiles(subFileInfo.ToString(), packInfo.SearchPattern,
                    SearchOption.TopDirectoryOnly);
                foreach (var fileInfo in subSubFiles)
                {
                    var assetPath = PathHelper.FormatPath(fileInfo.ToString());
                    var abName = FileHelper.GetAbName(assetPath);
                    var assetInfo = new AssetInfo(assetPath, abName, packInfo.PackAssetType);
                    
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