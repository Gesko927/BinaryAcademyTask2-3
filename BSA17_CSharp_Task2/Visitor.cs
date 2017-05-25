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
                    Console.WriteLine("Input type of animal: ");
                    var animalType = Console.ReadLine();
                    Console.WriteLine("Input animal`s name: ");
                    var name = Console.ReadLine();

                    if (animalType != null && name != null) Zoo.Add(animalType, name);
                }
                    break;

                case 2:
                {
                    Console.WriteLine("Input animal`s name: ");
                    var name = Console.ReadLine();

                    if (name != null) Zoo.Feed(name);
                }
                    break;

                case 3:
                {
                    Console.WriteLine("Input animal`s name: ");
                    var name = Console.ReadLine();

                    if (name != null) Zoo.Heal(name);
                }
                    break;

                case 4:
                {
                    Console.WriteLine("Input animal`s name: ");
                    var name = Console.ReadLine();

                    if (name != null) Zoo.Remove(name);
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