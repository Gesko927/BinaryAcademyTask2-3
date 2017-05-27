using System;
using BSA17_CSharp_Task2.AnimalFactory.Animals;

namespace BSA17_CSharp_Task2.AnimalFactory.Creators
{
    public class AnimalCreator: IAnimalCreator
    {
        public Animal Animal;

        public Animal CreateAnimal(string animalType, string name)
        {
            switch (animalType.ToLower())
            {
                case "lion":
                    {
                        Animal = new Lion(name, 5);
                    }
                    break;

                case "tiger":
                    {
                        Animal = new Tiger(name, 4);
                    }
                    break;

                case "elephant":
                    {
                        Animal = new Slon(name, 7);
                    }
                    break;

                case "bear":
                    {
                        Animal = new Bear(name, 6);
                    }
                    break;

                case "wolf":
                    {
                        Animal = new Wolf(name, 4);
                    }
                    break;

                case "fox":
                    {
                        Animal = new Fox(name, 3);
                    }
                    break;

                default:
                    break;
            }

          return Animal;
        }
    }
}