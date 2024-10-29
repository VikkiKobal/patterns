using System;

namespace Task_6
{
    public interface IProduct
    {
        string Name { get; }
        decimal Price { get; }
        bool Availability { get; set; }
        string GetProductDetails();
    }
}
