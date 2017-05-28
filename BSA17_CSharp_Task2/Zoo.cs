using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using BSA17_CSharp_Task2.AnimalFactory;
using BSA17_CSharp_Task2.AnimalFactory.Animals;
using BSA17_CSharp_Task2.AnimalFactory.Creators;

namespace BSA17_CSharp_Task2
{
    public class Zoo : IZooRepository<Animal>
    {
        public List<Animal> Animals;
        private readonly AnimalCreator _animalCreator;

        public Zoo()
        {
            Animals = new List<Animal>();
            _animalCreator = new AnimalCreator();
            InitZooHardCode();
        }

        private void InitZooHardCode()
        {
            AddAnimal("lion", "Alex");
            AddAnimal("fox", "Alina");
            AddAnimal("bear", "Misha");
            AddAnimal("tiger", "Wood");
            AddAnimal("wolf", "Serj");
            AddAnimal("elephant", "Kostya");
        }
        private void InitZooFromFile(string path)
        {
            if(File.Exists(path))
            {
                var s = File.ReadAllLines(path);
                foreach (var animal in s)
                {
                    var str = animal.Split(' ');
                    AddAnimal(str[0], str[1]);
                }
            }
            else
            {
                Console.WriteLine("Change path for file with animals data");
            }
        }

        public IEnumerable<Animal> GetAnimalList()
        {
            return Animals;
        }

        /// <summary>
        /// Return animals with selected name
        /// </summary>
        /// <param name="name">Animal`s name</param>
        /// <returns></returns>
        public Animal GetAnimal(string name)
        {
            return Animals.Where(animal => animal.Name == name).Select(animal => animal).SingleOrDefault();
        }

        /// <summary>
        /// Add animals with name and animal kind to zoo
        /// </summary>
        /// <param name="animalKind">Animal`s kind</param>
        /// <param name="name">Animal`s name</param>
        public void AddAnimal(string animalKind, string name)
        {
            Animals.Add(_animalCreator.CreateAnimal(animalKind, name));
            Console.WriteLine($"Added new {animalKind.ToUpper()} with name: {name}");
        }

        /// <summary>
        /// Heal animals with selected name on 1 Health
        /// </summary>
        /// <param name="name">Animal`s name</param>
        public void HealAnimal(string name)
        {
            var selectedAnimal = Animals.Where(animal => animal.Name == name && animal.Health < animal.MaxHealth).Select(animal =>
            {
                animal.Health++;
                return animal.Name;
            }).SingleOrDefault();

            Console.WriteLine(selectedAnimal != null ? $"Healed animal with name: {selectedAnimal}" : $"There is no animal with name: {name}");
        }

        /// <summary>
        /// Feed animal with selected name
        /// </summary>
        /// <param name="name">Animal`s name</param>
        public void FeedAnimal(string name)
        {
            var selectedAnimal = Animals.Where(animal => animal.Name == name).Select(animal =>
            {
                animal.State = AnimalState.Sated;
                return animal.Name;
            }).SingleOrDefault();

            Console.WriteLine(selectedAnimal != null ? $"Fed animal with name: {selectedAnimal}" : $"There is no animal with name: {name}");
        }

        /// <summary>
        /// Remove dead animal with selected name from zoo
        /// </summary>
        /// <param name="name">Animal`s name</param>
        public void RemoveAnimal(string name)
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

        public void GroupAllAnimalsByKind()
        {
            var query = Animals.GroupBy(animal => animal.GetType()).Select(animal => new
            {
                Kind = animal.Key.Name,
                Count = animal.Count()
            });

            foreach (var animal in query)
            {
                Console.WriteLine($"{animal.Kind} - {animal.Count}");
            }
        }

        public IEnumerable<Animal> AnimalsWithState(AnimalState state)
        {
            return Animals.Where(animal => animal.State == state).Select(animal => animal);
        }

        public IEnumerable<Animal> AllSickTigers()
        {
            return Animals.Where(animal => animal.GetType() == typeof(Tiger) && animal.State == AnimalState.Sick).Select(animal => animal);
        }

        public Animal ShowElephant(string name)
        {
            return Animals.SingleOrDefault(animal => animal.Name == name && animal.GetType() == typeof(Slon));
        }

        public IEnumerable<string> HungryAnimalsNames()
        {
            return Animals.Where(animal => animal.State == AnimalState.Hungry).Select(animal => animal.Name);
        }

        public IEnumerable<Animal> MaxHealthAnimalsPerKind()
        {
            return Animals.GroupBy(x => x.GetType().Name)
                .Select(animal => animal.Where(p=>p.Health == animal.Max(k=>k.Health)).Select(p=>p).SingleOrDefault());
        }

        public void DeadAnimalsPerKind()
        {
            var query = Animals.Where(animal => animal.State == AnimalState.Dead).GroupBy(animal => animal.GetType())
                .Select(
                    g => new
                    {
                        Name = g.Key.Name,
                        Count = g.Count()
                    });

            foreach (var animal in query)
            {
                Console.WriteLine($"{animal.Name} - {animal.Count}");
            }
        }

        public IEnumerable<Animal> AllWolvesAndBearsWithHealth(int health)
        {
            return Animals.Where(animal => (animal.GetType() == typeof(Wolf) || animal.GetType() == typeof(Bear)) &&
                                            animal.Health > health).Select(animal => animal);
        }

        public void ShowMaxAndMinHealthAnimals()
        {
            var query = Animals.Select(animal => new {
                Min = Animals.Where(x => x.Health == Animals.Min(y => y.Health)).Select(z=>z).SingleOrDefault(),
                Max = Animals.Where(x => x.Health == Animals.Max(y => y.Health)).Select(z=>z).SingleOrDefault()
            });

            foreach (var animal in query)
            {
                Console.WriteLine(animal.Max);
                Console.WriteLine(animal.Min);
                break;
            }
        }

        public double AverageHealthAnimals()
        {
            return Animals.Average(animal => animal.Health);
        }
    }
}