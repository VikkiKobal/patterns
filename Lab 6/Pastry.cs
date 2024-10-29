namespace Task_6.Products
{
    public class Pastry : IProduct
    {
        public string Name { get; }
        public decimal Price { get; }
        public bool Availability { get; set; }

        public Pastry(string name, decimal price, bool availability)
        {
            Name = name;
            Price = price;
            Availability = availability;
        }

        public string GetProductDetails()
        {
            return $"Випічка: {Name}, Ціна: {Price:C}, Наявністьі: {Availability}";
        }
    }
}
