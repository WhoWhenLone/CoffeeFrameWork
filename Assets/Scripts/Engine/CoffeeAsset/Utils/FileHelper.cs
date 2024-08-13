// FileHelper.cs
// Created by nancheng.
// DateTime: 2024年8月13日 19:12:22
// Desc: 

using System.Collections.Generic;
using System.IO;

namespace CoffeeAsset.Utils
{
    public class FileHelper
    {
        public static FileInfo[] GetAllFiles(string path, string pattern, SearchOption option)
        {
            var direction = new DirectoryInfo(path);
            return direction.GetFiles(pattern, option);
        }

        public static string GetAbName(string path)
        {
            return path;
        }
    }
}