using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_6
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> ProductList { get; set; }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
            ProductList = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            ProductList.Add(product);
        }

        public void ViewCategoryDetails()
        {
            Console.WriteLine($"ID категорії: {Id}\nНазва: {Name}\nПродукт:");

            if (ProductList.Count == 0)
            {
                Console.WriteLine("У категорії нема продуктів доступних до замовлення.");
            }
            else
            {
                foreach (var product in ProductList)
                {
                    Console.WriteLine(product.GetProductDetails());
                    Console.WriteLine(); 
                }
            }
        }
    }
}
