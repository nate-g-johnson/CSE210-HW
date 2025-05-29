using System;

class Program
{
    static void Main(string[] args)
    {
        // Order 1: USA Customer
        Address address1 = new Address("123 Elm St", "Springfield", "IL", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("T-shirt", "TS001", 15.00, 2));
        order1.AddProduct(new Product("Mug", "MG002", 8.50, 1));

        Console.WriteLine("Order 1 - Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Order 1 - Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Order 1 - Total Price: ${order1.GetTotalCost():F2}");
        Console.WriteLine();

        // Order 2: International Customer
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Notebook", "NB003", 12.00, 3));
        order2.AddProduct(new Product("Pen Set", "PN004", 5.25, 2));

        Console.WriteLine("Order 2 - Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Order 2 - Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Order 2 - Total Price: ${order2.GetTotalCost():F2}");
    }
}
