namespace Task_6.Products
{
    public class Cake : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool Availability { get; set; }

        public Cake(string name, decimal price, bool availability)
        {
            Name = name;
            Price = price;
            Availability = availability;
        }

        public string GetProductDetails()
        {
            return $"Торт: {Name}, Ціна: {Price:C}, Наявність: {Availability}";
        }
    }
}
