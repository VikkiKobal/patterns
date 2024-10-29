using System;
using System.Collections.Generic;

namespace Task_6
{
    public class Admin
    {
        public int Id { get; set; }
        public string Email { get; set; }

        public Admin(int id, string email)
        {
            Id = id;
            Email = email;
        }

        public void ViewProducts(List<Product> productList)
        {
            Console.WriteLine("Список продуктів:");
            if (productList.Count == 0)
            {
                Console.WriteLine("Продукти відсутні.");
                return;
            }

            foreach (var product in productList)
            {
                Console.WriteLine(product.GetProductDetails());
            }
        }

        public void UpdateProduct(Product product, string newTitle, string newDescription, double newPrice)
        {
            product.Title = newTitle;
            product.Description = newDescription;
            product.Price = newPrice;

            Console.WriteLine($"Продукт з ID {product.Id} успішно оновлено.");
        }

        public void AddProduct(List<Product> productList, string title, string description, bool availability, double price, Category category)
        {
            var newProduct = ProductFactory.CreateProduct(productList.Count, title, description, availability, price, category);
            productList.Add(newProduct);
            Console.WriteLine($"Продукт '{newProduct.Title}' успішно додано.");
        }
    }
}
