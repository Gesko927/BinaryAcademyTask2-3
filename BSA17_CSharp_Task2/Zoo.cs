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
            var path = Path.GetFullPath("Animals.txt");
            this.InitZooFromFile(path);
        }

        public void Add(string animalType, string name)
        {
            Animals.Add(_animalCreator.CreateAnimal(animalType, name));
            Console.WriteLine($"Added new {animalType.ToUpper()} with name: {name}");
        }

        public void Feed(string name)
        {
            var selectedAnimal = Animals.Where(animal => animal.Name == name).Select(animal =>
            {
                animal.State = AnimalState.Sated;
                return animal.Name;
            }).SingleOrDefault();

            Console.WriteLine(selectedAnimal != null ? $"Fed animal with name: {selectedAnimal}" : $"There is no animal with name: {name}");
            Console.ReadKey();
        }

        public void Heal(string name)
        {
            var selectedAnimal = Animals.Where(animal => animal.Name == name && animal.Health < animal.MaxHealth).Select(animal =>
                {
                    animal.Health++;
                    return animal.Name;
                }).SingleOrDefault();

            Console.WriteLine(selectedAnimal != null ? $"Healed animal with name: {selectedAnimal}" : $"There is no animal with name: {name}");
        }

        public void Remove(string name)
        {
            var removedAnimal = Animals.Where(animals => animals.Name == name && animals.State == AnimalState.Dead)
                .Select(animal => animal).SingleOrDefault();

            if (removedAnimal != null)
            {
                Animals.Remove(removedAnimal);
                Console.WriteLine($"Removed animal with name: {name}");
            }
            else
            {
                Console.WriteLine($"You can not remove animal with name: {name}");
            }
        }

        public void ShowAllAnimals()
        {
            foreach (var animal in Animals)
            {
                Console.WriteLine(animal);
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