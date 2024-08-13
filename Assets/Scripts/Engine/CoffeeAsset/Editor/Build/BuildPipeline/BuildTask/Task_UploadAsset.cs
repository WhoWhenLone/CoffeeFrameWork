// Task_UploadAsset.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:41:13
// Desc: 

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_UploadAsset : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_UploadAsset");
        }
    }
}