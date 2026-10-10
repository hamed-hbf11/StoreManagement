using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreManagement.Model;

namespace StoreManagement.Service
{
    public class OrderService
    {
        private readonly List<Order> _orders = new List<Order>();
        private int _nextOrderId = 1001;

        public OrderService(List<Order>? loadedOrders = null)
        {
            if (loadedOrders != null && loadedOrders.Count > 0)
            {
                _orders = loadedOrders;
                _nextOrderId = _orders.Max(o => o.Id) + 1;
            }
        }
        public List<Order> GetAllOrders() => _orders;
        public Order CreateOrder(List<CartItem> cartItems, decimal grandTotal)
        {
            List<CartItem> orderItems = new List<CartItem>();
            foreach (var item in cartItems)
            {
                orderItems.Add(new CartItem
                {
                    Product = item.Product,
                    Quantity = item.Quantity
                });
            }

            Order newOrder = new Order
            {
                Id = _nextOrderId++,
                Items = orderItems,
                TotalAmount = grandTotal,
                Status = "Completed"
            };

            _orders.Add(newOrder);
            return newOrder;
        }
    }
}