// Task_Prepare.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:06:59
// Desc: 准备工作
// 检测基础构建的参数，检测版本信息啥的

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_Prepare : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_Prepare");
        }
    }
}