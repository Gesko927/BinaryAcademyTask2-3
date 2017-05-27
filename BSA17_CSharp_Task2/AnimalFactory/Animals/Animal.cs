namespace BSA17_CSharp_Task2.AnimalFactory.Animals
{
    public abstract class Animal
    {
        protected Animal(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            Health = maxHealth;
            State = AnimalState.Sated;
        }
        public string Name { get; private set; }
        public int MaxHealth { get; private set; }
        public AnimalState State { get; set; }
        public int Health { get; set; }
        public override string ToString()
        {
            return $"Name: {Name}\t Health: {Health}\t State: {State.ToString()}";
        }
    }
}