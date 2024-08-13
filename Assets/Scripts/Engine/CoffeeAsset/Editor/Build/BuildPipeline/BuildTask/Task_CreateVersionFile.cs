// Task_CreateVersionFile.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:40:59
// Desc: 

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_CreateVersionFile : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_CreateVersionFile");
        }
    }
}