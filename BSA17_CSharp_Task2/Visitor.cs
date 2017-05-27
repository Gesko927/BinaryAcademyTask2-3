using System;

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
                        try
                        {
                            Console.WriteLine("Input kind of animal: ");
                            var animalKind = Console.ReadLine();
                            Console.WriteLine("Input animal`s name: ");
                            var name = Console.ReadLine();

                            if (animalKind != null && name != null)
                            {
                                Zoo.Add(animalKind, name);
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
                        Console.WriteLine("Input animal`s name: ");

                        try
                        {
                            var name = Console.ReadLine();
                            if (name != null) Zoo.Feed(name);
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
                        Console.WriteLine("Input animal`s name: ");

                        try
                        {
                            var name = Console.ReadLine();
                            if (name != null) Zoo.Heal(name);
                            
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
                        Console.WriteLine("Input animal`s name: ");
                        try
                        {
                            var name = Console.ReadLine();
                            if (name != null) Zoo.Remove(name);
                            
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
                        Zoo.ShowAllAnimals();
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