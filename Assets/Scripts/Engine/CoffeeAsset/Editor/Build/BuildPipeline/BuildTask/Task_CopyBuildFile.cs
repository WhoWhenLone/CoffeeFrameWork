﻿// Task_CopyBuildFile.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:41:05
// Desc: 

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_CopyBuildFile : IBuildTask
    {
        public void Run(BuildContext context)
        {
            AssetLogHelper.Log("Task_CopyBuildFile");
        }
    }
}