using System;

namespace Task_6
{
    public static class ProductFactory
    {
        public static Product CreateProduct(int id, string title, string description, bool availability, double price, Category category)
        {
            return new Product(id, title, description, availability, price, category);
        }
    }
}
