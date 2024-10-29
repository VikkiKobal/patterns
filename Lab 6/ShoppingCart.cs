using System;
using System.Collections.Generic;

namespace Task_6
{
    public class ShoppingCart
    {
        public DateTime CreatedDate { get; private set; }
        public List<CartItem> ProductList { get; private set; }

        public ShoppingCart()
        {
            CreatedDate = DateTime.Now;
            ProductList = new List<CartItem>();
        }

        public void AddToCart(Product product, int quantity)
        {
            if (!product.Availability)
            {
                Console.WriteLine($"Не вдалося додати {product.Title} до кошика. Продукт недоступний.");
                return;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Кількість повинна бути більшою за нуль.");
                return;
            }

            var existingItem = ProductList.Find(item => item.Product.Id == product.Id);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                Console.WriteLine($"Оновлено кількість {product.Title} до {existingItem.Quantity}.");
            }
            else
            {
                ProductList.Add(new CartItem(product, quantity));
                Console.WriteLine($"Додано {product.Title} до кошика.");
            }
        }

        public Order Checkout(Customer customer, string address)
        {
            if (ProductList.Count == 0)
            {
                Console.WriteLine("Ваш кошик порожній. Додайте продукти перед оформленням замовлення.");
                return null;
            }

            double totalCost = 0;
            foreach (var item in ProductList)
            {
                totalCost += item.Product.Price * item.Quantity;
            }

            Order order = new Order(OrderIdGenerator.Generate(), ProductList[0].Product, ProductList[0].Quantity);
            Console.WriteLine($"Замовлення створено з ID: {order.OrderId} та загальною вартістю: ${totalCost:F2}");

            ProductList.Clear();
            return order;
        }

        public void ViewDetails()
        {
            Console.WriteLine("Деталі кошика:");
            if (ProductList.Count == 0)
            {
                Console.WriteLine("Ваш кошик порожній.");
                return;
            }

            foreach (var item in ProductList)
            {
                Console.WriteLine($"{item.Product.Title} - Кількість: {item.Quantity} - Ціна: ${item.Product.Price:F2}");
            }
        }

        public void RemoveItem(int productId)
        {
            var itemToRemove = ProductList.Find(item => item.Product.Id == productId);
            if (itemToRemove != null)
            {
                ProductList.Remove(itemToRemove);
                Console.WriteLine($"{itemToRemove.Product.Title} було видалено з кошика.");
            }
            else
            {
                Console.WriteLine("Товар не знайдено в кошику.");
            }
        }
    }

    public class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

        public CartItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }

    public static class OrderIdGenerator
    {
        private static int currentId = 1;

        public static int Generate()
        {
            return currentId++;
        }
    }
}
