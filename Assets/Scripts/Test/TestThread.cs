using System;
using System.Threading;
using UnityEngine;

namespace CoffeeFrameWork
{
    public class TestThread
    {
        private Thread _thread;

        private long _count = 1;
        private Action _action;
        public bool IsDone = false;
        
        public TestThread(Action action)
        {
            _thread = new Thread(Run);
            _action = action;
            _count = 0;
            IsDone = false;
        }

        public void Start()
        {
            _thread.Start();
        }
        
        void Run()
        {
            while (!IsDone)
            {
                _count++;
                if (_count == 100000000)
                {
                    IsDone = true;
                    _action.Invoke();
                    UnityMainThreadDispatcher.Dispatcher.Enqueue(() =>
                    {
                        var go2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
                        go2.name = "main thread create 2";
                    });
                }
            }
        }
    }
}