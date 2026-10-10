using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagement.Model
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public List<CartItem> Items { get; set; } = new List<CartItem>();
        public decimal TotalAmount {get; set;}
        public string Status { get; set; }= "Completed";

        public override string ToString()
        {
            return $"Order #{Id,-5} | Date: {OrderDate:g} | Total: ${TotalAmount,-10} | Status: {Status}";
        }
    }
}