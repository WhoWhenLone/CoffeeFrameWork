// IBuildTask.cs
// Created by nancheng.
// DateTime: 2024年8月12日 18:45:47

namespace CoffeeAsset.Build
{
    public interface IBuildTask
    { 
        void Run(BuildContext context);
    }
}