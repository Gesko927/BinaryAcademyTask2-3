using System;
using System.IO;
using System.Threading;

namespace BSA17_CSharp_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Visitor visitor = new Visitor();
            Hunger hunger = new Hunger(visitor.Zoo);

            var tm = new TimerCallback(hunger.DoHunger);
            var timer = new Timer(tm, 1, 0, 5000);

            while (true)
            {
                Console.Clear();
                Menu();
                Console.WriteLine(Path.GetFullPath("Animals.txt"));
                Console.WriteLine("Your choise: ");
                try
                {
                    var choise = Convert.ToInt32(Console.ReadLine());
                    visitor.VisitorAction(choise);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please, choose correct number!");
                    Console.ReadKey();
                    
                }
            }
        }

        private static void Menu()
        {
            Console.WriteLine("Welcome to our zoo:");
            Console.WriteLine("1) Add new animal");
            Console.WriteLine("2) Feed existing animal");
            Console.WriteLine("3) Heal existing animal");
            Console.WriteLine("4) Remove existing animal");
            Console.WriteLine("5) Show all animals in zoo");
            Console.WriteLine("0) Exit");
        }
    }
}
