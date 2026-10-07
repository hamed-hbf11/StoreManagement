
using StoreManagement.Model;

namespace StoreManagement
{
    public class ProductService
    {
        private int _nextId = 1;
        private readonly List<Product> _products = new List<Product>();
        public Product AddProduct(string nameProduct, decimal PriceProduct, int stockProduct, string categoryProduct)
        {
            Product product = new Product
            {
                Id = _nextId++,
                Name = nameProduct,
                Price = PriceProduct,
                Stock = stockProduct,
                Category = categoryProduct
            };

            _products.Add(product);
            return product;
        }
        public List<Product> GetAllProducts()
        {
            return _products;
        }
        public List<Product> SearchProduct(string query)
        {
            var result = new List<Product>();

            foreach (var product in _products)
            {
                if (product.Name.ToLower().Contains(query.ToLower())
                || product.Category.ToLower().Contains(query.ToLower()))
                {
                    result.Add(product);
                }
            }

            return result;
        }
        public Product? GetProductById(int id)
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }
        public bool UpdateProduct(int id, string name, decimal price, int stock, string category)
        {
            Product? product = GetProductById(id);

            if (product == null)
            {
                return false;
            }

            product.Name = name;
            product.Price = price;
            product.Stock = stock;
            product.Category = category;

            return true;
        }
        public bool DeleteProduct(int id)
        {
            Product? product = GetProductById(id);

            if (product == null)
                return false;

            _products.Remove(product);
            return true;
        }
        public bool UpdateStock(int id, int newStock)
        {
            Product? product = GetProductById(id);

            if (product == null)
                return false;

            product.Stock = newStock;
            return true;
        }
    }
}