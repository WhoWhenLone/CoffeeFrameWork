// BuildPipeline.cs
// Created by nancheng.
// DateTime: 2024年8月12日 19:02:33
// Desc: 

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using Debug = UnityEngine.Debug;

namespace CoffeeAsset.Build
{
    public class BuildPipeline
    {
        private Stopwatch _stopwatch;

        public BuildResult ProcessBuildTask(BuildContext context)
        {
            var result = new BuildResult();
            result.Success = true;

            var totalTime = 0f;
            
            
            var list = GetBuildTasks();
            var totalCount = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                IBuildTask task = list[i];
                var taskName = task.GetType().Name;
                try
                {
                    EditorUtility.DisplayProgressBar("构建资源", taskName, i / totalCount);
                    
                    Debug.Log($"---------------------构建任务{taskName}---------------------");
                    
                    _stopwatch = Stopwatch.StartNew();
                    task.Run(context);
                    _stopwatch.Stop();
                    var curSeconds = _stopwatch.ElapsedMilliseconds / 1000;
                    totalTime += curSeconds;
                    
                    Debug.Log($"构建结束，时长 = {curSeconds}");
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.FailedTask = taskName;
                    result.ErrorInfo = e.ToString();
                    break;
                }
            }

            EditorUtility.ClearProgressBar();
            
            Debug.Log($"构建资源总用时 = {totalTime}");
            return result;
        }
        
        private List<IBuildTask> GetBuildTasks()
        {
            var list = new List<IBuildTask>()
            {
                // 预准备
                new Task_Prepare(),
                
                // 收集Bundle组信息
                new Task_CollectBundleGroups(),
                
                // 创建所有Bundle信息
                new Task_CreateBuildBundles(),
                
                // 构建Bundle
                new Task_BuildBundle(),
                
                // 生成资源清单
                new Task_CreateManifest(),
                
                // 生成版本信息
                new Task_CreateVersionFile(),
                
                // 拷贝数据
                new Task_CopyBuildFile(),
                
                // 上传资源
                new Task_UploadAsset(),
            };

            return list;
        }
    }
}