using BSA17_CSharp_Task2.AnimalFactory.Animals;

namespace BSA17_CSharp_Task2.AnimalFactory.Creators
{
    public interface IAnimalCreator
    {
        Animal CreateAnimal(string animalType, string name);
    }
}