using System;
using System.Threading;

namespace BSA17_CSharp_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Zoo zoo = new Zoo();
            Hunger hunger = new Hunger(zoo);

            Menu();

            Console.WriteLine("Your choise: ");
            var choise = Convert.ToInt32(Console.ReadLine());

            TimerCallback tm = new TimerCallback(hunger.DoHunger);

            Timer timer = new Timer(tm, 1, 0, 5000);

            while (true)
            {
                switch (choise)
                {
                    case 1:
                        {
                            Console.WriteLine("Input type of animal: ");
                            var animalType = Console.ReadLine();
                            Console.WriteLine("Input animal`s name: ");
                            var name = Console.ReadLine();

                            zoo.Add(animalType, name);
                        }
                        break;

                    case 2:
                        {
                            Console.WriteLine("Input animal`s name: ");
                            var name = Console.ReadLine();

                            zoo.Feed(name);
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("Input animal`s name: ");
                            var name = Console.ReadLine();

                            zoo.Heal(name);
                        }
                        break;

                    case 4:
                        {
                            Console.WriteLine("Input animal`s name: ");
                            var name = Console.ReadLine();

                            zoo.Remove(name);
                        }
                        break;

                    case 0:
                        {
                            return;
                        }
                        break;

                    default:
                        break;

                } 
            }



        }

        static void Menu()
        {
            Console.WriteLine("Welcome to our zoo:");
            Console.WriteLine("1) Add new animal");
            Console.WriteLine("2) Feed existing animal");
            Console.WriteLine("3) Heal existing animal");
            Console.WriteLine("4) Remove existing animal");
            Console.WriteLine("0) Exit");
        }

        static void ShowMenu()
        {
            Menu();
            var choise = Convert.ToInt32(Console.Read());
        }
    }
}
