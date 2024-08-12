// BuildLauncher.cs
// Created by nancheng.
// DateTime: 2024年8月12日 18:43:00
// Desc: 构建Bundle启动器

namespace CoffeeAsset.Build
{
    public class BuildLauncher
    {
        public static void ExecuteBuildBundle(BuildParams param)
        {
            var buildContext = new BuildContext();
            var buildParamContext = new BuildParamContext(param);
            buildContext.AddContextObject(buildParamContext);
            
            var buildPipeline = new CoffeeAsset.Build.BuildPipeline();
            buildPipeline.ProcessBuildTask(buildContext);
        }
    }
}