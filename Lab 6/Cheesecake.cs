namespace Task_6.Products
{
    public class Cheesecake : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool Availability { get; set; }

        public Cheesecake(string name, decimal price, bool availability)
        {
            Name = name;
            Price = price;
            Availability = availability;
        }

        public string GetProductDetails()
        {
            return $"Чизкейк: {Name}, Ціна: {Price:C}, Наявність: {Availability}";
        }
    }
}
