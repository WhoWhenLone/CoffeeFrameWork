using UnityEngine;

namespace CoffeeFrameWork
{
    public class TestSingletonMono : SingletonBehavior<TestSingletonMono>
    {
        public int a;
        [SerializeField]
        private string _aaaa = "aaaaa";

        private int _index = 0;
        
        protected override void OnUpdate(float delta)
        {
            base.OnUpdate(delta);
            _index++;
            // Debug.LogError(_index);
        }
        
        public string GetName()
        {
            return _aaaa;
        }
    }
}
