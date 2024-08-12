// BuildPackInfo.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:24:47
// Desc: 

using System.Collections.Generic;

namespace CoffeeAsset.Build
{
    public class BuildPackInfo
    {
        public string PackName;

        public string AssetPath;
        
        public PackRuleType PackRuleType;

        public List<BuildAssetInfo> AssetInfos;

        public string SearchPattern;

        public DeliverType DeliverType;

        public List<BuildAssetInfo> GetAllAssetInfos()
        {
            var list = new List<BuildAssetInfo>();

            return list;
        }
    }
}