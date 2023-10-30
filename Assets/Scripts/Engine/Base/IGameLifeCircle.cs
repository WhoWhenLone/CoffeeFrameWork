namespace CoffeeFrameWork
{
    public interface IGameLifeCircle
    {
        public void Init();
        public void OnEnter();
        public void OnUpdate(float deltaTime);
        public void OnFixUpdate();
        public void OnLateUpdate();
        public void OnExit();
    }
}
