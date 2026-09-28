using System;

namespace StoreManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("    STORE MANAGEMENT    ");
                Console.WriteLine("========================");
                Console.WriteLine("1. Product");
                Console.WriteLine("2. Cart");
                Console.WriteLine("3. Order");
                Console.WriteLine("0. Exit");
                Console.WriteLine("========================");
                Console.Write("Select an Option: ");

                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}