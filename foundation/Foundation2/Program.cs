using System;
using System.Collections.Generic;

namespace OnlineOrdering
{
    // Address Class
    public class Address
    {
        private string Street { get; set; }
        private string City { get; set; }
        private string State { get; set; }
        private string Country { get; set; }

        public Address(string street, string city, string state, string country)
        {
            Street = street;
            City = city;
            State = state;
            Country = country;
        }

        public bool IsInUSA()
        {
            return Country.Equals("USA", StringComparison.OrdinalIgnoreCase);
        }

        public string GetFullAddress()
        {
            return $"{Street}\n{City}, {State}\n{Country}";
        }
    }

    // Customer Class
    public class Customer
    {
        private string Name { get; set; }
        private Address CustomerAddress { get; set; }

        public Customer(string name, Address address)
        {
            Name = name;
            CustomerAddress = address;
        }

        public bool LivesInUSA()
        {
            return CustomerAddress.IsInUSA();
        }

        public string GetCustomerInfo()
        {
            return $"{Name}\n{CustomerAddress.GetFullAddress()}";
        }
    }

    // Product Class
    public class Product
    {
        private string Name { get; set; }
        private string ProductID { get; set; }
        private decimal Price { get; set; }
        private int Quantity { get; set; }

        public Product(string name, string productId, decimal price, int quantity)
        {
            Name = name;
            ProductID = productId;
            Price = price;
            Quantity = quantity;
        }

        public decimal GetTotalCost()
        {
            return Price * Quantity;
        }

        public string GetPackingInfo()
        {
            return $"{Name} (ID: {ProductID})";
        }
    }

    // Order Class
    public class Order
    {
        private List<Product> Products { get; set; }
        private Customer OrderCustomer { get; set; }

        public Order(Customer customer)
        {
            OrderCustomer = customer;
            Products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public decimal CalculateTotalCost()
        {
            decimal totalCost = 0;
            foreach (var product in Products)
            {
                totalCost += product.GetTotalCost();
            }

            // Add shipping cost
            totalCost += OrderCustomer.LivesInUSA() ? 5 : 35;
            return totalCost;
        }

        public string GetPackingLabel()
        {
            var packingLabel = "Packing Label:\n";
            foreach (var product in Products)
            {
                packingLabel += $"{product.GetPackingInfo()}\n";
            }
            return packingLabel;
        }

        public string GetShippingLabel()
        {
            return $"Shipping Label:\n{OrderCustomer.GetCustomerInfo()}";
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Create addresses
            var address1 = new Address("123 Main St", "Springfield", "IL", "USA");
            var address2 = new Address("456 Elm St", "Toronto", "ON", "Canada");

            // Create customers
            var customer1 = new Customer("John Doe", address1);
            var customer2 = new Customer("Jane Smith", address2);

            // Create products
            var product1 = new Product("Laptop", "A123", 800m, 1);
            var product2 = new Product("Mouse", "B456", 25m, 2);
            var product3 = new Product("Monitor", "C789", 150m, 1);
            var product4 = new Product("Keyboard", "D012", 50m, 1);

            // Create orders
            var order1 = new Order(customer1);
            order1.AddProduct(product1);
            order1.AddProduct(product2);

            var order2 = new Order(customer2);
            order2.AddProduct(product3);
            order2.AddProduct(product4);

            // Display details for each order
            Console.WriteLine(order1.GetPackingLabel());
            Console.WriteLine(order1.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():0.00}\n");

            Console.WriteLine(order2.GetPackingLabel());
            Console.WriteLine(order2.GetShippingLabel());
            Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():0.00}");
        }
    }
}
