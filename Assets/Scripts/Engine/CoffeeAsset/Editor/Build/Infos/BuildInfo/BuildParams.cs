// BuildParams.cs
// Created by nancheng.
// DateTime: 2024年8月12日 20:39:03

using UnityEditor;

namespace CoffeeAsset.Build
{
    public class BuildParams
    {
        /// <summary>
        /// 资源版本号
        /// </summary>
        public string AssetVersion;

        /// <summary>
        /// app版本号
        /// </summary>
        public string AppVersion;

        /// <summary>
        /// 配置版本号
        /// </summary>
        public string CfgVersion;

        /// <summary>
        /// 资源输出文件夹
        /// </summary>
        public string BuildOutputRoot;

        /// <summary>
        /// bundle名称类型
        /// </summary>
        public FileNameStyle FileNameStyle;

        /// <summary>
        /// 资源构建模式
        /// </summary>
        public BuildMode BuildMode;

        /// <summary>
        /// 构建操作
        /// </summary>
        public BuildAssetBundleOptions BuildOptions;

        /// <summary>
        /// 构建平台
        /// </summary>
        public BuildTarget BuildTarget;
    }
}