namespace BSA17_CSharp_Task2.AnimalFactory.Animals
{
    public class Slon:Animal
    {
        public Slon(string name, int maxHealth) : base(name, maxHealth)
        {
        }

        public override string ToString()
        {
            return $"{GetType().Name}\t {base.ToString()}";
        }
    }
}