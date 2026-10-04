
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
    }
}