namespace CoffeeFrameWork
{
    public class TestSingle : Singleton<TestSingle>
    {
        private string _name = "test singleton";
        
        public override void Initialize()
        {
            _name = "aonms singleton";
        }
        
        public string GetName()
        {
            return _name;
        }
    }
}
