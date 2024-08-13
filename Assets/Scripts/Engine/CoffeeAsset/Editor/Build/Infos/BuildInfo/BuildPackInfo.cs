// BuildPackInfo.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:24:47
// Desc: 

using System;
using System.Collections.Generic;
using CoffeeAsset.Build.CollectInfo;
using CoffeeAsset.Build.PackRule;
using Sirenix.OdinInspector;
using static CoffeeAsset.PackRuleType;

namespace CoffeeAsset.Build
{
    [Serializable]
    public class BuildPackInfo
    {
        /// <summary>
        /// 资源包名字
        /// </summary>
        public string PackName;

        /// <summary>
        /// 资源路径
        /// </summary>
        [FolderPath]
        public string AssetPath;
        
        /// <summary>
        /// 收集规则
        /// </summary>
        public PackRuleType PackRuleType;

        /// <summary>
        /// 资源类型
        /// </summary>
        public PackAssetType PackAssetType;

        /// <summary>
        /// 搜索过滤
        /// </summary>
        public string SearchPattern;

        /// <summary>
        /// 资源分发类型
        /// </summary>
        public DeliverType DeliverType;
        
        public List<CollectBundleInfo> CollectBundleInfos()
        {
            var packRule = CreatePackRule();
            return packRule.GetBuildBundleInfo(this);
        }

        private IPackRule CreatePackRule()
        {
            switch (PackRuleType)
            {
                case PackRuleType.Single:
                    return new PackRule_Single();
                case PackRuleType.SubDic:
                    return new PackRule_SubDic();
                case PackRuleType.SubSubDic:
                    return new PackRule_SubSubDic();
                case PackRuleType.All:
                    return new PackRule_All();
                break;
            }

            return new PackRule_Single();
        }
    }
}