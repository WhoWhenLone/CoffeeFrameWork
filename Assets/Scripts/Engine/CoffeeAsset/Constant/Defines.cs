// Defines.cs
// Created by nancheng.
// DateTime: 2024年8月12日 20:58:40
// Desc: 

using Sirenix.OdinInspector;

namespace CoffeeAsset
{
    public enum FileNameStyle
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        FileName = 0,
        
        /// <summary>
        /// hash值
        /// </summary>
        HashName = 1,
        
        /// <summary>
        /// 文件名加hash值
        /// </summary>
        FileName_Hash = 2,
    }

    public enum BuildMode
    {
        /// <summary>
        /// 强制重新构建
        /// </summary>
        [LabelText("强制重新构建，清除已构建的资源")]
        ForceReBuild,
        
        /// <summary>
        /// 增量构建
        /// </summary>
        [LabelText("基于之前构建的资源，接着构建")]
        IncrementBuild,
        
        /// <summary>
        /// 模拟构建
        /// </summary>
        [LabelText("编辑器模拟测试构建")]
        SimulateBuild,
    }

    public enum PackRuleType
    {
        /// <summary>
        /// 每个资源一个bundle
        /// </summary>
        [LabelText("每个资源一个bundle")]
        Single = 0,
        
        /// <summary>
        /// 子文件夹一个bundle
        /// </summary>
        [LabelText("子文件夹一个bundle")]
        SubDic,
        
        /// <summary>
        /// 子文件夹的子文件夹一个bundle
        /// </summary>
        [LabelText("子文件夹的子文件夹一个bundle")]
        SubSubDic,
        
        /// <summary>
        /// 一个bundle
        /// </summary>
        [LabelText("一个bundle")]
        All,
    }

    public enum DeliverType
    {
        /// <summary>
        /// 包内资源 带进包里的资源，热更的时候写在资源清单里
        /// </summary>
        [LabelText("进包")]
        InPackage,
        
        /// <summary>
        /// 包外热更下载
        /// </summary>
        [LabelText("边玩边下")]
        HotUpdate,
    }

    public enum PackAssetType
    {
        /// <summary>
        /// 收集的主资源，写到资源清单里的，可以通过代码加载
        /// </summary>
        [LabelText("主资源")]
        MainAsset,
        
        /// <summary>
        /// 依赖资源，只能通过加载主资源，依赖加载到的（例如场景中的小摆件）
        /// </summary>
        [LabelText("依赖资源")]
        DependAsset,
    }
}