// FileHelper.cs
// Created by nancheng.
// DateTime: 2024年8月13日 19:12:22
// Desc: 

using System.Collections.Generic;
using System.IO;
using UnityEditor;

namespace CoffeeAsset.Utils
{
    public class FileHelper
    {
        public static FileInfo[] GetAllFiles(string path, string pattern, SearchOption option)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                pattern = "*";
            }

            var direction = new DirectoryInfo(path);
            return direction.GetFiles(pattern, option);
        }

        public static string GetAbName(string path)
        {
            return path;
        }

        public static bool CheckFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            return Directory.Exists(path);
        }

        public static void CreateFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }

            Directory.CreateDirectory(path);
        }

        public static string GetTargetFolder(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return "Android";
                case BuildTarget.StandaloneWindows:
                    return "PC";
                case BuildTarget.iOS:
                    return "IOS";
            }
            
            return "Default";
        }
    }
}