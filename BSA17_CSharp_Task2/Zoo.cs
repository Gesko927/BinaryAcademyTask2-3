using System;
using System.Collections.Generic;
using System.Linq;
using BSA17_CSharp_Task2.AnimalFactory;
using BSA17_CSharp_Task2.AnimalFactory.Animals;
using BSA17_CSharp_Task2.AnimalFactory.Creators;

namespace BSA17_CSharp_Task2
{
    public class Zoo
    {
        public List<Animal> Animals;
        private readonly AnimalCreator _animalCreator;

        public Zoo()
        {
            Animals = new List<Animal>();
            _animalCreator = new AnimalCreator();
        }

        public void Add(string animalType, string name)
        {
            Animals.Add(_animalCreator.CreateAnimal(animalType, name));
            Console.WriteLine($"Added new {animalType.ToUpper()} with name: {name}");
        }

        public void Feed(string name)
        {
            foreach (var animal in Animals)
            {
                if (animal.Name == name)
                {
                    animal.State = AnimalState.Sated;
                    Console.WriteLine($"Fed animal with name: {name}");
                }
            }
        }

        public void Heal(string name)
        {
            foreach (var animal in Animals)
            {
                if (animal.Name == name)
                {
                    if (animal.Health < animal.MaxHealth)
                    {
                        ++animal.Health;
                        Console.WriteLine($"Healed animal with name: {name}");
                    }
                    else
                    {
                        Console.WriteLine($"Animal {name} is completely healthy");
                    }
                }
            }
        }

        public void Remove(string name)
        {
            foreach (var animal in Animals)
            {
                if (animal.State == AnimalState.Dead)
                {
                    Animals.Remove(animal);
                    Console.WriteLine($"Removed animal with name: {name}");
                }
            }
        }
    }
}