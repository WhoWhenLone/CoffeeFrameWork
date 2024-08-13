// IPackRule.cs
// Created by nancheng.
// DateTime: 2024年8月13日 15:11:22
// Desc: 

using System.Collections.Generic;
using CoffeeAsset.Build.CollectInfo;

namespace CoffeeAsset.Build
{
    public interface IPackRule
    {
        public List<CollectBundleInfo> GetBuildBundleInfo(BuildPackInfo packInfo);
    }
}