using System;
using System.Collections.Generic;
using Task_6;

public class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }

    public Customer(int customerId, string name, string phone, string email, string address)
    {
        CustomerId = customerId;
        Name = name;
        Phone = phone;
        Email = email;
        Address = address;
    }

    public void ViewDesserts(List<Product> desserts)
    {
        Console.WriteLine("Доступні десерти:");

        if (desserts.Count == 0) 
        {
            Console.WriteLine("Десертів немає в наявності.");
            return; 
        }

        foreach (var dessert in desserts)
        {
            Console.WriteLine(dessert.GetProductDetails());
            Console.WriteLine(); 
        }
    }

    public void PlaceOrder(Order order)
    {
        Console.WriteLine($"Замовлення на {order.Quantity} одиниць '{order.Product.Title}' зроблено {Name}.");
    }
}
