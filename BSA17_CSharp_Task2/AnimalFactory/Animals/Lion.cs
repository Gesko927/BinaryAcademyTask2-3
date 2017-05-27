using BSA17_CSharp_Task2.AnimalFactory.Animals;

namespace BSA17_CSharp_Task2.AnimalFactory
{
    public class Lion:Animal
    {
        public Lion(string name, int maxHealth) : base(name, maxHealth)
        {
        }

        public override string ToString()
        {
            return GetType().Name + base.ToString();
        }
    }
}