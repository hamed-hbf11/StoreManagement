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
            Console.WriteLine("4. Edit Product");
            Console.WriteLine("5. Delete Product");
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
                case "4":
                    EditProduct();
                    break;
                case "5":
                    DeleteProduct();
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

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("\nSearch term cannot be empty.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

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
        public static void EditProduct()
        {
            Console.Clear();
            Console.WriteLine(" === Edit Product ===");
            Console.WriteLine("Enter Product ID to Edit: ");

            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Product ID Format.");
                Console.WriteLine("press Enter to Continue...");
                Console.ReadLine();
                return;
            }

            Product? existingProduct = _productService.GetProductById(id);

            if (existingProduct == null)
            {
                Console.WriteLine("Product with this ID not found.");
                Console.WriteLine("press Enter to Continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nEditing Product: {existingProduct.Name}");
            Console.WriteLine("----------------------------------");

            Console.Write($"New Name (Current: {existingProduct.Name}): ");
            string inputName = Console.ReadLine() ?? "";
            string newName = string.IsNullOrWhiteSpace(inputName) ? existingProduct.Name : inputName;

            Console.Write($"New Price (Current: {existingProduct.Price}): ");
            string inputPrice = Console.ReadLine() ?? "";
            decimal newPrice = decimal.TryParse(inputPrice, out decimal parsedPrice) ? parsedPrice : existingProduct.Price;

            Console.Write($"New Stock (Current: {existingProduct.Stock}): ");
            string inputStock = Console.ReadLine() ?? "";
            int newStock = int.TryParse(inputStock, out int parsedStock) ? parsedStock : existingProduct.Stock;

            Console.Write($"New Category (Current: {existingProduct.Category}): ");
            string inputCategory = Console.ReadLine() ?? "";
            string newCategory = string.IsNullOrWhiteSpace(inputCategory) ? existingProduct.Category : inputCategory;

            _productService.UpdateProduct(id, newName, newPrice, newStock, newCategory);
            Console.WriteLine("Product updated successfully.");
            Console.WriteLine("press Enter to continue... ");
            Console.ReadLine();
        }
        public static void DeleteProduct()
        {
            Console.Clear();
            Console.WriteLine("=== Delete Product ===");

            Console.Write("Enter search term to find the product to delete: ");
            string query = Console.ReadLine() ?? "";
            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("\nSearch term cannot be empty.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            List<Product> results = _productService.SearchProduct(query);

            if (results.Count == 0)
            {
                Console.WriteLine("\nNo Products found matching your search term.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nSearch Results for '{query}':");
            PrintProductList(results);

            Console.Write("\nEnter Product ID to Delete (or press Enter to cancel):");
            string inputId = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(inputId))
            {
                Console.WriteLine("\nDeletion cancelled.");
                Console.WriteLine("Press anu key to continue...");
                Console.ReadLine();
                return;
            }

            if (!int.TryParse(inputId, out int id))
            {
                Console.WriteLine("\nInvalid Product ID format.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Product? product = _productService.GetProductById(id);
            if (product == null)
            {
                Console.WriteLine("\nProduct with this ID was not found in the overall Product list");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
                return;
            }

            Console.Write($"\nAre you sure you want to delete the product '{product.Name}' (ID: {product.Id})? (y/n): ");
            string confirm = Console.ReadLine()?.ToLower() ?? "";

            if (confirm == "y")
            {
                _productService.DeleteProduct(id);
                Console.WriteLine("Product deleted successfully.");
            }
            else
            {
                Console.WriteLine("\nDeletion cancelled.");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();

        }
    }
}