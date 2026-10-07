using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Model
{
    public class CartItem
    {
        public Product Product { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal TotalPrice => Product.Price * Quantity;
        public override string ToString()
        {
            return $"{Product.Id,-5} {Product.Name, -20} {Product.Price,-10} {Quantity, -8} ${TotalPrice}";
        }
    }
}