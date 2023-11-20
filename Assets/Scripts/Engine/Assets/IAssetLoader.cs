using System;

public interface IAssetLoader
{
    public void LoadAsset_Async<T>(string path);
    public void LoadAsset_Async(string path, System.Type type);
    
    public void LoadAsset_Sync<T>(string path);
    public void LoadAsset_Sync(string path, System.Type type);

    public void ReleaseAsset(string path);
}