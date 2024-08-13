// Task_CreateManifest.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:53
// Desc: 生成资源清单

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_CreateManifest : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_CreateManifest");
        }
    }
}