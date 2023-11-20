// File:    AssetManager.cs
// Author:  nancheng
// Date:    2023-6-5 14:23:45
// Desc:    资源管理

using CoffeeFrameWork;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.AddressableAssets;
using Object = System.Object;

public class AssetManager : Singleton<AssetManager>
{
    private IAssetLoader _loader;

    public override void Initialize()
    {
#if UNITY_EDITOR
        _loader = new AssetLoaderEditor();
#else
        _loader = new AssetLoaderEditor();
#endif
    }

    public T LoadAsset_Async<T>(string path, Action<Object> callback)
    {
        return _loader:LoadAsset_Async<T>(path, callback);
    }

    public void InstantiateAsset<T>(string path, Action callback)
    {
        
    }

    public void ReleaseAsset(string path, Action callback)
    {
        
    }

    public void ReleaseInstantiate(string path, Action callback)
    {
        
    }
}