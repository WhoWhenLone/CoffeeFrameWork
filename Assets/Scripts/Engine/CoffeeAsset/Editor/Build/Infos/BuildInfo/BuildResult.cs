// BuildResult.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:45:46
// Desc: 

namespace CoffeeAsset.Build
{
    public class BuildResult
    {
        /// <summary>
        /// 是否构建成功
        /// </summary>
        public bool Success;

        /// <summary>
        /// 构建失败的任务
        /// </summary>
        public string FailedTask;

        /// <summary>
        /// 构建失败的信息
        /// </summary>
        public string ErrorInfo;
    }
}