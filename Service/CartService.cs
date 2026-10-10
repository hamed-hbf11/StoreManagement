using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Model;

namespace StoreManagement.Service
{
    public class CartService
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();
        private readonly ProductService _productService;

        public CartService(ProductService productService)
        {
            _productService = productService;
        }
        public List<CartItem> GetCartItems()
        {
            return _cartItems;
        }
        public bool AddToCart(int productId, int quantity)
        {
            Product? product = _productService.GetProductById(productId);

            if (product == null || product.Stock < quantity)
                return false;

            product.Stock -= quantity;
            CartItem? existingItem = _cartItems.Find(item => item.Product.Id == productId);

            if (existingItem != null)
                existingItem.Quantity += quantity;
            else
            {
                _cartItems.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            return true;
        }
        public decimal GetCartTotal()
        {
            decimal total = 0;
            foreach (var item in _cartItems)
                total += item.TotalPrice;

            return total;
        }
        public void ClearCart()
        {
            _cartItems.Clear();
        }
        public bool RemoveFromCart(int productId)
        {
            CartItem? item = _cartItems.Find(i => i.Product.Id == productId);

            if (item == null)
                return false;

            item.Product.Stock += item.Quantity;
            _cartItems.Remove(item);
            return true;
        }
    }
}