using System;

public class AssetLoaderEditor : IAssetLoader
{
    public void LoadAsset_Async<T>(string path, Action<Object> callback) where T : Object
    {
        
    }

    public void LoadAsset_Async(string path, Type type)
    {
    }

    public Object LoadAsset_Sync<T>(string path) where T : Object, new()
    {
        return new T();
    }

    public object LoadAsset_Sync(string path, Type type)
    {
        return default;
    }

    public void ReleaseAsset(string path)
    {
        
    }
}