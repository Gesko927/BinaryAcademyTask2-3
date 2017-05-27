using BSA17_CSharp_Task2.AnimalFactory.Animals;

namespace BSA17_CSharp_Task2.AnimalFactory
{
    public class Tiger:Animal
    {
        public Tiger(string name, int maxHealth) : base(name, maxHealth)
        {
        }

        public override string ToString()
        {
            return $"{GetType().Name}\t {base.ToString()}";
        }
    }
}