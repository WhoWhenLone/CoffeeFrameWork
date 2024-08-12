// BuildParamContext.cs
// Created by nancheng.
// DateTime: 2024年8月12日 20:39:12
// Desc: 

namespace CoffeeAsset.Build
{
    public class BuildParamContext : IContextObject
    {
        public BuildParams Params;
        
        public BuildParamContext(BuildParams param)
        {
            Params = param;
        }
    }
}