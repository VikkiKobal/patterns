using System;
using System.Collections.Generic;

namespace Task_6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dessertCategory = new Category(1, "Десерти");
            var admin = new Admin(1, "admin@example.com");
            var customer = new Customer(1, "John Doe", "123456789", "john@example.com", "123 Main St");

            admin.AddProduct(dessertCategory.ProductList, "Шоколадний торт", "Опис торта ...", true, 25.99, dessertCategory);
            admin.AddProduct(dessertCategory.ProductList, "Чизкейк", "Опис чизкейку ....", false, 20.99, dessertCategory);

            while (true)
            {
                Console.WriteLine("Виберіть свою роль: ");
                Console.WriteLine("1. Адміністратор");
                Console.WriteLine("2. Клієнт");
                Console.WriteLine("3. Вихід");
                Console.Write("Введіть свій вибір (1-3): ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminActions(admin, dessertCategory);
                        break;
                    case "2":
                        CustomerActions(customer, dessertCategory);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private static void AdminActions(Admin admin, Category dessertCategory)
        {
            while (true)
            {
                Console.WriteLine("\nДії адміністратора: ");
                Console.WriteLine("1. Додати продукт");
                Console.WriteLine("2. Переглянути продукти");
                Console.WriteLine("3. Вихід до головного меню");
                Console.Write("Введіть свій вибір (1-3): ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть назву продукту: ");
                        var productName = Console.ReadLine();
                        Console.Write("Введіть опис продукту: ");
                        var productDescription = Console.ReadLine();
                        Console.Write("Продукт доступний? (true/false): ");
                        var isAvailable = bool.Parse(Console.ReadLine());
                        Console.Write("Введіть ціну продукту: ");
                        var price = decimal.Parse(Console.ReadLine());

                        admin.AddProduct(dessertCategory.ProductList, productName, productDescription, isAvailable, (double)price, dessertCategory);
                        Console.WriteLine("Продукт успішно додано!");
                        break;
                    case "2":
                        Console.WriteLine("Доступні продукти:");
                        foreach (var product in dessertCategory.ProductList)
                        {
                            Console.WriteLine($"- {product.Title}: ${product.Price:F2} - {(product.Availability ? "Доступний" : "Недоступний")}");
                        }
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }

        private static void CustomerActions(Customer customer, Category dessertCategory)
        {
            var cart = new ShoppingCart();

            while (true)
            {
                Console.WriteLine("\nДії клієнта: ");
                Console.WriteLine("1. Переглянути десерти");
                Console.WriteLine("2. Додати до кошика");
                Console.WriteLine("3. Оформити замовлення");
                Console.WriteLine("4. Вихід до головного меню");
                Console.Write("Введіть свій вибір (1-4): ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        customer.ViewDesserts(dessertCategory.ProductList);
                        break;
                    case "2":
                        Console.Write("Введіть індекс продукту для додавання до кошика: ");
                        var productIndex = int.Parse(Console.ReadLine());
                        Console.Write("Введіть кількість: ");
                        var quantity = int.Parse(Console.ReadLine());

                        if (productIndex >= 0 && productIndex < dessertCategory.ProductList.Count)
                        {
                            var product = dessertCategory.ProductList[productIndex];

                            if (!product.Availability)
                            {
                                Console.WriteLine("Недостатня кількість в наявності.");
                            }
                            else
                            {
                                cart.AddToCart(product, quantity);
                                Console.WriteLine($"{quantity} одиниць {product.Title} додано до кошика.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Невірний індекс продукту.");
                        }
                        break;

                    case "3":
                        Console.WriteLine("Виберіть метод отримання сповіщення: ");
                        Console.WriteLine("1. WhatsApp");
                        Console.WriteLine("2. SMS");
                        Console.WriteLine("3. Email");
                        Console.Write("Введіть свій вибір (1-3): ");
                        var notificationChoice = Console.ReadLine();
                        INotificationMethod notificationMethod = null;

                        switch (notificationChoice)
                        {
                            case "1":
                                notificationMethod = new WhatsAppNotification();
                                break;
                            case "2":
                                notificationMethod = new SMSNotification(); 
                                break;
                            case "3":
                                notificationMethod = new EmailNotification(); 
                                break;
                            default:
                                Console.WriteLine("Невірний вибір. Використовується WhatsApp за замовчуванням.");
                                notificationMethod = new WhatsAppNotification();
                                break;
                        }

                        var order = cart.Checkout(customer, customer.Address);
                        if (order != null)
                        {
                            Console.WriteLine($"ID замовлення: {order.OrderId}, Загальна вартість: ${order.OrderCost:F2}, Статус: {order.OrderStatus}");
                            order.ConfirmOrder();
                            order.SendNotification(notificationMethod, customer.Name);
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}
