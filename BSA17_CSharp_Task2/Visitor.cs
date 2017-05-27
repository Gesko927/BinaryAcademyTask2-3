using System;
using BSA17_CSharp_Task2.AnimalFactory;

namespace BSA17_CSharp_Task2
{
    public class Visitor
    {
        public readonly Zoo Zoo;

        public Visitor()
        {
            Zoo = new Zoo();
        }

        #region LINQ Methods
        private void AddAnimalInZoo()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("Input kind of animal: ");
                var animalKind = Console.ReadLine();
                Console.WriteLine("Input animal`s name: ");
                var name = Console.ReadLine();

                if (animalKind != null && name != null)
                {
                    Zoo.AddAnimal(animalKind, name);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Input correct name or kind!");
            }
            Console.ReadKey();
        }
        private void FeedAnimalInZoo()
        {
            Console.Clear();
            Console.WriteLine("Input animal`s name: ");

            try
            {
                var name = Console.ReadLine();
                if (name != null) Zoo.FeedAnimal(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Input correct name!");
            }
            Console.ReadKey();
        }
        private void HealAnimalInZoo()
        {
            Console.Clear();
            Console.WriteLine("Input animal`s name: ");

            try
            {
                var name = Console.ReadLine();
                if (name != null) Zoo.HealAnimal(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Input correct name!");
            }

            Console.ReadKey();
        }
        private void RemoveAnimalInZoo()
        {
            Console.Clear();
            Console.WriteLine("Input animal`s name: ");
            try
            {
                var name = Console.ReadLine();
                if (name != null) Zoo.RemoveAnimal(name);
            }
            catch (Exception e)
            {
                Console.WriteLine("Input correct name!");
            }

            Console.ReadKey();
        }
        private void ShowAllAnimalsInZoo()
        {
            Console.Clear();
            foreach (var animal in Zoo.GetAnimalList())
            {
                Console.WriteLine(animal);
            }
            Console.ReadKey();
        }
        private void ShowAnimalsWithState()
        {
            Console.Clear();
            Console.WriteLine("1) Sated");
            Console.WriteLine("2) Hungry");
            Console.WriteLine("3) Sick");
            Console.WriteLine("4) Dead");

            try
            {
                var num = Convert.ToInt32(Console.ReadLine());
                AnimalState state = AnimalState.Sated;
                bool res = false;

                switch (num)
                {
                    case 1:
                    {
                        state = AnimalState.Sated;
                        res = true;
                    }
                        break;

                    case 2:
                    {
                        state = AnimalState.Hungry;
                        res = true;
                    }
                        break;

                    case 3:
                    {
                        state = AnimalState.Sick;
                        res = true;
                    }
                        break;

                    case 4:
                    {
                        state = AnimalState.Dead;
                        res = true;
                    }
                        break;

                    default:
                        res = false;
                        break;

                }

                if (res)
                {
                    foreach (var animal in Zoo.AnimalsWithState(state))
                    {
                        Console.WriteLine(animal);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Input correct number!");
            }
            Console.ReadKey();
        }
        private void ShowElephant()
        {
            Console.Clear();
            Console.WriteLine("Input elephant`s name:");
            var name = Console.ReadLine();
            Console.WriteLine(Zoo.ShowElephant(name));
            Console.ReadKey();
        }
        private void ShowSickTigers()
        {
            Console.Clear();
            foreach (var animal in Zoo.AllSickTigers())
            {
                Console.WriteLine(animal);
            }
            Console.ReadKey();
        }
        private void ShowHungryAnimalsNames()
        {
            Console.Clear();
            foreach (var animal in Zoo.HungryAnimalsNames())
            {
                Console.WriteLine(animal);
            }
            Console.ReadKey();
        }
        private void GroupByKind()
        {
            Console.Clear();
            Zoo.GroupAllAnimalsByKind();
            Console.ReadKey();
        }
        private void MaxHealthAnimals()
        {
            Console.Clear();
            foreach (var animal in Zoo.MaxHealthAnimalsPerKind())
            {
                Console.WriteLine(animal);
            }
            Console.ReadKey();
        }
        private void DeadAnimalsPerKind()
        {
            Console.Clear();
            Zoo.DeadAnimalsPerKind();
            Console.ReadKey();
        }
        private void ShowWolvesAndBears()
        {
            Console.Clear();
            Console.WriteLine("Input health:");
            try
            {
                var health = Convert.ToInt32(Console.ReadLine());

                foreach (var animal in Zoo.AllWolvesAndBearsWithHealth(health))
                {
                    Console.WriteLine(animal);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Input correct number of health");
            }
            Console.ReadKey();
        }
        private void ShowAverageHealthInZoo()
        {
            Console.Clear();
            Console.WriteLine($"Average health: {Zoo.AverageHealthAnimals()}");
            Console.ReadKey();
        }
        private void ShowMinAndMaxHealthAnimals()
        {
            Console.Clear();
            Zoo.ShowMaxAndMinHealthAnimals();
            Console.ReadKey();
        }
        #endregion

        public void VisitorAction(int choise)
        {
            switch (choise)
            {
                #region 15 Cases

                case 1: AddAnimalInZoo(); break;

                case 2: FeedAnimalInZoo(); break;

                case 3: HealAnimalInZoo(); break;

                case 4: RemoveAnimalInZoo(); break;

                case 5: ShowAllAnimalsInZoo(); break;

                case 6: GroupByKind(); break;

                case 7: ShowAnimalsWithState(); break;

                case 8: ShowSickTigers(); break;

                case 9: ShowElephant(); break;

                case 10: ShowHungryAnimalsNames(); break;

                case 11: MaxHealthAnimals(); break;

                case 12: DeadAnimalsPerKind(); break;

                case 13: ShowWolvesAndBears(); break;

                case 14: ShowMinAndMaxHealthAnimals(); break;

                case 15: ShowAverageHealthInZoo(); break;

                case 0: Environment.Exit(0); break;

                #endregion

                default: Console.WriteLine("Invalid choise. Try again!"); break;
            }
        }
    }
}