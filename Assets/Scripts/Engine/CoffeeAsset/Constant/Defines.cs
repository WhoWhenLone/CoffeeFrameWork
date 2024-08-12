// Defines.cs
// Created by nancheng.
// DateTime: 2024年8月12日 20:58:40
// Desc: 

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
        ForceReBuild,
        
        /// <summary>
        /// 增量构建
        /// </summary>
        IncrementBuild,
        
        /// <summary>
        /// 模拟构建
        /// </summary>
        SimulateBuild,
    }

    public enum PackRuleType
    {
        /// <summary>
        /// 每个资源一个bundle
        /// </summary>
        Single = 0,
        
        /// <summary>
        /// 子文件夹一个bundle
        /// </summary>
        SubDic,
        
        /// <summary>
        /// 子文件夹的子文件夹一个bundle
        /// </summary>
        SubSubDic,
        
        /// <summary>
        /// 一个bundle
        /// </summary>
        All,
    }

    public enum DeliverType
    {
        /// <summary>
        /// 包内资源
        /// </summary>
        InPackage,
        
        /// <summary>
        /// 包外热更下载
        /// </summary>
        HotUpdate,
    }
}