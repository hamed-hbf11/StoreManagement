namespace StoreManagement.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{Id,-5} {Name,-20} {Price,-10:F2} {Stock,-8} {Category}";
        }
    }
}