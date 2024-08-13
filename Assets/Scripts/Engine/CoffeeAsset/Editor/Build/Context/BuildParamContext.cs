// BuildParamContext.cs
// Created by nancheng.
// DateTime: 2024年8月12日 20:39:12
// Desc: 

using CoffeeAsset.Utils;

namespace CoffeeAsset.Build
{
    public class BuildParamContext : IContextObject
    {
        public BuildParams Params;
        
        public BuildParamContext(BuildParams param)
        {
            Params = param;
        }

        public bool CheckParam()
        {
            if (Params == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(Params.AppVersion))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Params.AssetVersion))
            {
                return false;
            }
            
            return true;
        }
        
        public string GetBuildOutputFolder()
        {
            return Params.BuildOutputRoot + "/" + FileHelper.GetTargetFolder(Params.BuildTarget) + "/" + Params.AssetVersion;
        }
    }
}