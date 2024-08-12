// BuildContext.cs
// Created by nancheng.
// DateTime: 2024年8月12日 18:47:43
// Desc: 

using System;
using System.Collections.Generic;

namespace CoffeeAsset.Build
{
    public class BuildContext
    {
        private readonly Dictionary<System.Type, IContextObject> _contextObjects = new Dictionary<Type, IContextObject>();

        public void AddContextObject(IContextObject contextObject)
        {
            if (contextObject == null)
            {
                throw new Exception("contextObject is null");
            }

            var type = contextObject.GetType();
            if (_contextObjects.ContainsKey(type))
            {
                throw new Exception($"context object {type} is existed");
            }
            
            _contextObjects.Add(type, contextObject);
        }

        public T GetContextObject<T>() where T : IContextObject
        {
            var type = typeof(T);
            if (_contextObjects.TryGetValue(type, out var contextObject))
            {
                return (T)contextObject;
            }

            throw new Exception($"not find context object {type}");
        }

        public void ClearAllContextObject()
        {
            _contextObjects.Clear();
        }
    }
}