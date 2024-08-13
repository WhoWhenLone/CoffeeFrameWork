// AssetLogHelper.cs
// Created by nancheng.
// DateTime: 2024年8月13日 15:43:09
// Desc: 

namespace CoffeeAsset.Utils
{
    public class AssetLogHelper
    {
        public static void Log(string msg)
        {
            if (BuildSetting.EnableLog)
            {
                UnityEngine.Debug.Log(msg);
            }
        }
        
        public static void LogWarning(string msg)
        {
            if (BuildSetting.EnableLog)
            {
                UnityEngine.Debug.LogWarning(msg);
            }
        }
        
        public static void LogError(string msg)
        {
            if (BuildSetting.EnableLog)
            {
                UnityEngine.Debug.LogError(msg);
            }
        }
    }
}