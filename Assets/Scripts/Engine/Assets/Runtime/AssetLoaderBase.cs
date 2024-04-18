using System;

public abstract class AssetLoaderBase
{
    public delegate void LoadAssetCallback(Object obj);
    
    public virtual void LoadAsset_Async<T>(string path, LoadAssetCallback callback) { }
    public virtual void LoadAsset_Async(string path, System.Type type, LoadAssetCallback callback) { }
    public virtual void LoadAsset_Sync<T>(string path, LoadAssetCallback callback) { }
    public virtual void LoadAsset_Sync(string path, System.Type type, LoadAssetCallback callback) { }
    public virtual void ReleaseAsset(string path) { }
}