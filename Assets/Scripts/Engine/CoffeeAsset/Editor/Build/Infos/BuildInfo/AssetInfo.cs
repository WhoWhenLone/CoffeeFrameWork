// AssetInfo.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:49:59
// Desc: 

using System.Collections.Generic;
using UnityEditor;

namespace CoffeeAsset.Build
{
    public class AssetInfo
    {
        /// <summary>
        /// 资源所归属的BundleName
        /// </summary>
        public string BelongAbName;
        
        /// <summary>
        /// 资源路径
        /// </summary>
        public string AssetPath;

        /// <summary>
        /// 资源GUID
        /// </summary>
        public string AssetGUID;

        /// <summary>
        /// 资源类型
        /// </summary>
        public System.Type AssetType;

        public AssetInfo(string path, string belongAbName)
        {
            BelongAbName = belongAbName;
            AssetPath = path;
            AssetGUID = AssetDatabase.AssetPathToGUID(path);
            AssetType = AssetDatabase.GetMainAssetTypeAtPath(path);
        }
    }
}