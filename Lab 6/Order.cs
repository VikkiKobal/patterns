using System;

namespace Task_6
{
    public class Order
    {
        public int OrderId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double OrderCost => Product.Price * Quantity;
        public string OrderStatus { get; set; }

        public Order(int orderId, Product product, int quantity)
        {
            OrderId = orderId;
            Product = product;
            Quantity = quantity;
            OrderStatus = "В очікуванні";
        }

        public void ConfirmOrder()
        {
            OrderStatus = "Підтверджено";
            Console.WriteLine($"Замовлення {OrderId} підтверджено.");
        }

        public void SendNotification(INotificationMethod notificationMethod, string recipient)
        {
            if (notificationMethod == null)
            {
                Console.WriteLine("Метод сповіщення не може бути null.");
                return;
            }

            if (string.IsNullOrEmpty(recipient))
            {
                Console.WriteLine("Отримувач не може бути порожнім.");
                return;
            }

            notificationMethod.Send($"Ваше замовлення з ID {OrderId} підтверджено. Загальна вартість: ${OrderCost:F2}", recipient);
        }
    }
}
