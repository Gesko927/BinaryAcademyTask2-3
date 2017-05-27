using System;
using System.Collections.Generic;
using System.Linq;
using BSA17_CSharp_Task2.AnimalFactory;
using BSA17_CSharp_Task2.AnimalFactory.Animals;

namespace BSA17_CSharp_Task2
{
    public interface IZooRepository<T> where T : class
    {
        IEnumerable<T> GetAnimalList();
        T GetAnimal(string name);
        void AddAnimal(string animalKind, string name);
        void HealAnimal(string name);
        void FeedAnimal(string name);
        void RemoveAnimal(string name);
        void GroupAllAnimalsByKind();
        IEnumerable<T> AnimalsWithState(AnimalState state);
        IEnumerable<T> AllSickTigers();
        T ShowElephant(string name);
        IEnumerable<string> HungryAnimalsNames();
        IEnumerable<T> MaxHealthAnimalsPerKind();
        void DeadAnimalsPerKind();
        IEnumerable<T> AllWolvesAndBearsWithHealth(int health);
        void ShowMaxAndMinHealthAnimals();
        double AverageHealthAnimals();
    }
}