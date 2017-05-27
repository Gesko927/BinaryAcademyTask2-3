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

        public void VisitorAction(int choise)
        {
            switch (choise)
            {
                case 1:
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
                    break;

                case 2:
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
                    break;

                case 3:
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
                    break;

                case 4:
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
                    break;

                case 5:
                    {
                        Console.Clear();
                        foreach (var animal in Zoo.GetAnimalList())
                        {
                            Console.WriteLine(animal);
                        }
                        Console.ReadKey();
                    }
                    break;

                case 6:
                    {
                        Console.Clear();
                        Zoo.GroupAllAnimalsByKind();
                        Console.ReadKey();
                    }
                    break;

                case 7:
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
                    break;

                case 8:
                    {
                        Console.Clear();
                        foreach (var animal in Zoo.AllSickTigers())
                        {
                            Console.WriteLine(animal);
                        }
                        Console.ReadKey();
                    }
                    break;

                case 9:
                    {
                        Console.Clear();
                        Console.WriteLine("Input elephant`s name:");
                        var name = Console.ReadLine();
                        Console.WriteLine(Zoo.ShowElephant(name));
                        Console.ReadKey();
                    }
                    break;

                case 10:
                    {
                        Console.Clear();
                        foreach (var animal in Zoo.HungryAnimalsNames())
                        {
                            Console.WriteLine(animal);
                        }
                        Console.ReadKey();
                    }
                    break;

                case 11:
                    {
                        Console.Clear();
                        Zoo.MaxHealthAnimalsPerKind();
                        Console.ReadKey();
                    }
                    break;

                case 12:
                    {
                        Console.Clear();
                        Zoo.DeadAnimalsPerKind();
                        Console.ReadKey();
                    }
                    break;

                case 13:
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
                    break;

                case 14:
                    {
                        Console.Clear();
                        Zoo.ShowMaxAndMinHealthAnimals();
                        Console.ReadKey();
                    }
                    break;

                case 15:
                    {
                        Console.Clear();
                        Console.WriteLine($"Average health: {Zoo.AverageHealthAnimals()}");
                        Console.ReadKey();
                    }
                    break;

                case 0:
                    {
                        Environment.Exit(0);
                    }
                    break;

                default:
                    {
                        Console.WriteLine("Invalid choise. Try again!");
                    }
                    break;
            }
        }
    }
}