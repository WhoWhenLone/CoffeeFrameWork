// Task_Prepare.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:06:59
// Desc: 准备工作
// 检测基础构建的参数，检测版本信息啥的

using System;
using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class Task_Prepare : IBuildTask
    {
        public void Run(BuildContext context)
        {
            var buildParamContext = context.GetContextObject<BuildParamContext>();
            if (buildParamContext == null)
            {
                throw new Exception("buildParamContext is null");
            }

            if (buildParamContext.CheckParam() == false)
            {
                throw new Exception("check param is failed");
            }
            
            var buildOutputFolder = buildParamContext.GetBuildOutputFolder();
            if (FileHelper.CheckFolder(buildOutputFolder) == false)
            {
                FileHelper.CreateFolder(buildOutputFolder);
            }
            
            
            AssetLogHelper.Log("Task_Prepare");
        }
    }
}