namespace CoffeeFrameWork
{
    public abstract class GameBaseModule : IGameLifeCircle
    {
        public abstract void Init();
        public abstract void OnEnter();
        public abstract void OnUpdate(float deltaTime);
        public abstract void OnFixUpdate();
        public abstract void OnLateUpdate();
        public abstract void OnExit();
    }
}
