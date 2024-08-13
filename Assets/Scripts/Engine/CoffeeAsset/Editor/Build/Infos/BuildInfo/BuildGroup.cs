// BuildGroup.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:20:56
// Desc: 

using System.Collections.Generic;
using CoffeeAsset.Build.CollectInfo;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace CoffeeAsset.Build
{
    [CreateAssetMenu(menuName = "CoffeeAsset/CreateBuildGroup", fileName = "build_group")]
    public class BuildGroup : ScriptableObject
    {
        [FolderPath]
        public string GroupName;

        [ListDrawerSettings]
        public List<BuildPackInfo> BuildPackInfos;

        public List<CollectBundleInfo> CollectBundleInfos()
        {
            var list = new List<CollectBundleInfo>();
            for (int i = 0; i < BuildPackInfos.Count; i++)
            {
                var packInfo = BuildPackInfos[i];
                list.AddRange(packInfo.CollectBundleInfos());
            }

            return list;
        }
    }
}