using System;

namespace Task_6
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
        public double Price { get; set; }
        public Category ProductCategory { get; set; } 

        public Product(int id, string title, string description, bool availability, double price, Category category)
        {
            Id = id;
            Title = title;
            Description = description;
            Availability = availability;
            Price = price;
            ProductCategory = category; 
        }

        public string GetProductDetails()
        {
            return $"Product ID: {Id}\n" +
                   $"Title: {Title}\n" +
                   $"Description: {Description}\n" +
                   $"Available: {(Availability ? "Yes" : "No")}\n" +
                   $"Price: ${Price:F2}\n" +
                   $"Category: {ProductCategory.Name}";
        }
    }
}
