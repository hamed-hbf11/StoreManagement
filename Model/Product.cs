namespace StoreManagement
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
            return $"ID: {Id} | Name: {Name} | Price: {Price} | Stock: {Stock} | Category: {Category}";
        }
    }
}