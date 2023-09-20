// File:    AssetManager.cs
// Author:  nancheng
// Date:    2023-6-5 14:23:45
// Desc:    资源管理

using CoffeeFrameWork;
using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetManager : GameBaseModule
{

    public static void LoadAsset<T>(string address, Action callback)
    {
        
    }

    public static void InstantiateAsset<T>(string address, Action callback)
    {

        
    }

    public static void ReleaseAsset(string address, Action callback)
    {
        
    }

    public static void ReleaseInstantiate(string address, Action callback)
    {
        
    }
    public override void Init()
    {
        throw new NotImplementedException();
    }
    public override void OnEnter()
    {
        throw new NotImplementedException();
    }
    public override void OnUpdate(float deltaTime)
    {
        throw new NotImplementedException();
    }
    public override void OnFixUpdate()
    {
        throw new NotImplementedException();
    }
    public override void OnLateUpdate()
    {
        throw new NotImplementedException();
    }
    public override void OnExit()
    {
        throw new NotImplementedException();
    }
}