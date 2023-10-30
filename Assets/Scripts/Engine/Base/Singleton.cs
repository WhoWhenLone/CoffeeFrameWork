using System;
using UnityEngine;

namespace CoffeeFrameWork
{
    public abstract class Singleton<T> where T : Singleton<T>, new()
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = default(T) == null ? Activator.CreateInstance<T>() : default;
                    }
                }
                
                return _instance;
            }
        }
        
        private static T _instance;
        private static readonly object _lock;
        
        static Singleton()
        {
            _lock = new object();
        }
        
        public virtual void Initialize() { }
        public virtual void OnUpdate(float deltaTime) { }
        public virtual void Release() { }
    }

    public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
    {
        public enum UpdateMode
        {
            UPDATE,
            LATE_UPDATE,
            FIX_UPDATE
        }
        
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = FindObjectOfType<T>();

                        if (FindObjectsOfType<T>().Length > 0)
                        {
                            Debug.LogError("SingletonBehavior instance more than 1");
                            return _instance;
                        }

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject("Singleton " + typeof(T).ToString());
                            _instance = singleton.AddComponent<T>();
                            
                            DontDestroyOnLoad(singleton);
                            
                            singleton.transform.SetParent(GameLauncher.Instance.SingletonRoot);
                        }
                        else
                        {
                            Debug.LogError("instance is created" + typeof(T).ToString());
                        }
                    }
                }

                return _instance;
            }
        }

        private static T _instance;
        private static readonly object _lock = new object();

        public UpdateMode updateMode = UpdateMode.UPDATE;

        private void Update()
        {
            if (updateMode == UpdateMode.UPDATE) OnUpdate(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if(updateMode == UpdateMode.FIX_UPDATE) OnUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            if(updateMode == UpdateMode.LATE_UPDATE) OnUpdate(Time.deltaTime);
        }

        protected virtual void OnUpdate(float delta) { }
        public virtual void Release() { }
    }
}
