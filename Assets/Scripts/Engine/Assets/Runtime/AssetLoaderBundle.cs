// File:    AssetManager.cs
// Author:  nancheng
// Date:    2023-6-5 14:23:45
// Desc:    真机资源管理

using System;

public class AssetLoaderBundle : AssetLoaderBase
{
    public override void LoadAsset_Async<T>(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        return;
    }

    public override void LoadAsset_Async(string path, Type type, AssetLoaderBase.LoadAssetCallback callback)
    {
        return;
    }

    public override void LoadAsset_Sync<T>(string path, AssetLoaderBase.LoadAssetCallback callback)
    {
        return;
    }

    public override void LoadAsset_Sync(string path, Type type, AssetLoaderBase.LoadAssetCallback callback)
    {
        return;
    }

    public override void ReleaseAsset(string path)
    {
        return;
    }
}