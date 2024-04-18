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
    private AssetLoaderBase _loader;

    public override void Initialize()
    {
#if UNITY_EDITOR
        _loader = new AssetLoaderEditor();
#else
        _loader = new AssetLoaderEditor();
#endif
    }

    public void LoadAsset_Async<T>(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        if (_loader != null)
        {
            _loader.LoadAsset_Async<T>(path, callback);   
        }
    }

    public void LoadAsset_Async(string path, Type type, AssetLoaderBase.LoadAssetCallback callback)
    {
        if (_loader != null)
        {
            _loader.LoadAsset_Async(path, type, callback);
        }
    }
    
    public void LoadAsset_Sync<T>(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        if (_loader != null)
        {
            _loader.LoadAsset_Sync<T>(path, callback);
        }
    }

    public void LoadAsset_Sync(string path, Type type, AssetLoaderBase.LoadAssetCallback callback)
    {
        if (_loader != null)
        {
            _loader.LoadAsset_Sync(path, type, callback);
        }
    }
    
    public void InstantiateAsset<T>(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        
    }

    public void ReleaseAsset(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        
    }

    public void ReleaseInstantiate(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        
    }
}