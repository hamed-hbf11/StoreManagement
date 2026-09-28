using System;
using System.Runtime.Intrinsics.Arm;

namespace StoreManagement
{
    public class Program
    {
        private static readonly ProductService _productService = new ProductService();
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
                    case "1":
                        ProductMenu();
                        break;
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

        public static void ProductMenu()
        {
            Console.Clear();
            Console.WriteLine("========================");
            Console.WriteLine("    Product MANAGEMENT    ");
            Console.WriteLine("========================");
            Console.WriteLine("1. Add Product");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("========================");
            Console.Write("Select an Option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Invalid option! Please try again.");
                    Console.ReadKey();
                    break;
            }
        }
        public static void AddProduct()
        {
            Console.Clear();
            Console.WriteLine(" === Add Product ===");

            Console.Write("Product Name: ");
            string nameProduct = Console.ReadLine() ?? "";

            Console.Write("Price: ");
            decimal priceProduct = decimal.Parse(Console.ReadLine() ?? "0");

            Console.Write("Stock: ");
            int stockProduct = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Category: ");
            string categoryProduct = Console.ReadLine() ?? "";

            _productService.AddProduct(nameProduct, priceProduct,stockProduct,categoryProduct);

            Console.WriteLine("\nProduct Add Product");
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
            
        }
    }
}