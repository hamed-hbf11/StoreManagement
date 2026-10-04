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
            Console.WriteLine("2. Show Products");
            Console.WriteLine("3. Search Products");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("========================");
            Console.Write("Select an Option: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    AddProduct();
                    break;
                case "2":
                    ShowProducts();
                    break;
                case "3":
                    SearchProducts();
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

            _productService.AddProduct(nameProduct, priceProduct, stockProduct, categoryProduct);

            Console.WriteLine("\nProduct Add Product");
            Console.WriteLine("press any key to continue...");
            Console.ReadLine();
        }

        public static void ShowProducts()
        {
            Console.Clear();
            Console.WriteLine(" === Show Products ===");

            var products = _productService.GetAllProducts();
            if (products.Count == 0)
            {
                Console.WriteLine("No products found!");
            }
            else
            {
                Console.WriteLine($"{"ID",-5} {"Name",-20} {"Price",-11} {"Stock",-8} {"Category"}");
                Console.WriteLine(new string('-', 55));

                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        public static void SearchProducts()
        {
            Console.Clear();
            Console.WriteLine(" === Search Products ===");

            Console.Write("Enter search Name or Category: ");
            string query = Console.ReadLine() ?? "";

            var results = _productService.SearchProduct(query);

            Console.WriteLine($"\n=== Search Results For {query} ===\n");
            PrintProductList(results);

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        public static void PrintProductList(List<Product> products)
        {
            if (products.Count == 0)
            {
                Console.WriteLine("No products found!");
            }

            Console.WriteLine($"{"ID",-5} {"Name",-20} {"Price",-11} {"Stock",-8} {"Category"}");
            Console.WriteLine(new string('-', 55));

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}