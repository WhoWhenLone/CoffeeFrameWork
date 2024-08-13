// PathHelper.cs
// Created by nancheng.
// DateTime: 2024年8月12日 21:16:00
// Desc: 

using System.IO;
using UnityEngine;

namespace CoffeeAsset.Utils
{
    public class PathHelper
    {
        public static string GetStringAssetPath()
        {
            return "";
        }

        public static string GetDataPath()
        {
            return Application.dataPath;
        }
        
        public static string GetFileName(string path, bool withoutEx = false)
        {
            if (withoutEx)
            {
                return Path.GetFileNameWithoutExtension(path);
            }
            return Path.GetFileName(path);
        }

        public static string FormatPath(string fullPath)
        {
            return fullPath.Substring(GetDataPath().Length - 6).Replace('\\', '/');
        }
    }
}