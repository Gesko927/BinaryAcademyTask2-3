using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BSA17_CSharp_Task2.AnimalFactory;

namespace BSA17_CSharp_Task2
{
    class Hunger
    {
        private Random _random;

        private readonly Zoo _zoo;

        public Hunger(Zoo zoo)
        {
            _random = new Random();
            _zoo = zoo;
        }

        public void DoHunger(object obj)
        {
            int animalIndex = _random.Next(0, _zoo.Animals.Count - 1);

            if (_zoo.Animals[animalIndex].State == AnimalState.Sated)
            {
                _zoo.Animals[animalIndex].State = AnimalState.Hungry;
            }
            else if (_zoo.Animals[animalIndex].State == AnimalState.Hungry)
            {
                _zoo.Animals[animalIndex].State = AnimalState.Sick;
            }
            else if (_zoo.Animals[animalIndex].State == AnimalState.Sick)
            {
                if (_zoo.Animals[animalIndex].Health > 0)
                {
                    --_zoo.Animals[animalIndex].Health;
                }
                else
                {
                    _zoo.Animals[animalIndex].State = AnimalState.Dead;
                }
            }

            Console.WriteLine("DoHunger");
        }
    }
}
