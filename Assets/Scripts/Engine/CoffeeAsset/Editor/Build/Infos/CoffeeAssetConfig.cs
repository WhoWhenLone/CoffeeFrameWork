// CoffeeAssetConfig.cs
// Created by nancheng.
// DateTime: 2024年8月13日 18:24:02
// Desc: 资源构建配置

using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace CoffeeAsset.Build
{
    [CreateAssetMenu(menuName = "CoffeeAsset/Create Asset Config", fileName = "asset_config")]
    public class CoffeeAssetConfig : ScriptableObject
    {
        [Header("App版本")]
        public string AppVersion;
        [Header("资源版本")]
        public string ResVersion;
        [Header("构建输出路径")]
        [FolderPath]
        public string OutputPath;
        
        [ListDrawerSettings]
        public List<BuildGroup> BuildGroups;
    }
}