// Task_BuildBundle.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:48
// Desc: 构建Bundle资源

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_BuildBundle : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_BuildBundle");
        }
    }
}