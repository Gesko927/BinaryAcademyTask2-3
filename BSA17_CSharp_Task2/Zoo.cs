using System;
using System.Collections.Generic;
using System.IO;
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
            this.InitZooFromFile("C:\\Users\\Gesko927\\OneDrive\\VisualProjects\\BSA17_CSharp_Task2\\BSA17_CSharp_Task2\\Animals.txt");
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

        private void InitZooFromFile(string path)
        {
            if(File.Exists(path))
            {
                var s = File.ReadAllLines(path);
                foreach (var animal in s)
                {
                    var str = animal.Split(' ');
                    this.Add(str[0], str[1]);
                }
            }
            else
            {
                Console.WriteLine("Change path for file with animals data");
            }
        }
    }
}