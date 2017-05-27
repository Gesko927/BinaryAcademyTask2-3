namespace BSA17_CSharp_Task2.AnimalFactory.Animals
{
    public class Bear:Animal
    {
        public Bear(string name, int maxHealth) : base(name, maxHealth)
        {
            
        }

        public override string ToString()
        {
            return GetType().Name + base.ToString();
        }
    }
}