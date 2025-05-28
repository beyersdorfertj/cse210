using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World! W04 Assignment: Online Ordering Program");
        List<Order> orders = CreateSampleOrders();

        foreach (var order in orders) {
            Console.WriteLine($"\nOrder ID: {order.GetOrderId()}");
            Console.WriteLine("Packing Label:");
            Console.WriteLine(order.GetPackingLabel());
            Console.WriteLine("Shipping Label:");
            Console.WriteLine(order.GetShippingLabel());
            Console.WriteLine($"Total Price: ${order.GetTotalPrice()}");
            Console.WriteLine();
        }
    }

    static List<Order> CreateSampleOrders() {
        Order order1 = new Order(1, new Customer("Alice", new Address("123 Main St", "Anytown", "CA", "USA")));
        order1.AddProduct(new Product(123, "Laptop", 1200.00m, 1));
        order1.AddProduct(new Product(124, "Mouse", 25.00m, 2));

        Order order2 = new Order(2, new Customer("Bob", new Address("456 Elm St", "Othertown", "CA", "USA")), 
                                  new Address("460 Elm St", "Othertown", "CA", "USA"));
        order2.AddProduct(new Product(125, "Monitor", 300.00m, 1));
        order2.AddProduct(new Product(126, "Keyboard", 45.00m, 1));
        order2.AddProduct(new Product(127, "USB Cable", 10.00m, 3));

        return new List<Order> { order1, order2 };
    }
}