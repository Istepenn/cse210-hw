using System;
using System.Collections.Generic;

class Product {
    public string Name { get; set; }
    public int ProductId { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }

    public Product(string name, int productId, double price, int quantity) {
        Name = name;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalCost() {
        return Price * Quantity;
    }
}

class Address {
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }

    public Address(string street, string city, string state, string country) {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA() {
        return Country.ToLower() == "usa";
    }

    public string FormatAddress() {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

class Customer {
    public string Name { get; set; }
    public Address Address { get; set; }

    public Customer(string name, Address address) {
        Name = name;
        Address = address;
    }

    public bool IsInUSA() {
        return Address.IsInUSA();
    }
}

class Order {
    private List<Product> products;
    public Customer Customer { get; set; }

    public Order(Customer customer) {
        Customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product) {
        products.Add(product);
    }

    public double CalculateTotalCost() {
        double totalCost = 0;
        foreach (var product in products) {
            totalCost += product.GetTotalCost();
        }
        return totalCost + (Customer.IsInUSA() ? 5 : 35);
    }

    public string GeneratePackingLabel() {
        string label = "Packing Label:\n";
        foreach (var product in products) {
            label += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    public string GenerateShippingLabel() {
        return $"Shipping Label:\n{Customer.Name}\n{Customer.Address.FormatAddress()}";
    }
}

class Program {
    static void Main(string[] args) {
        Address address1 = new Address("123 Main St", "City1", "State1", "USA");
        Customer customer1 = new Customer("Customer1", address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Product1", 1, 10, 2));
        order1.AddProduct(new Product("Product2", 2, 15, 1));

        Console.WriteLine(order1.GeneratePackingLabel());
        Console.WriteLine(order1.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost()}");

        Address address2 = new Address("456 Elm St", "City2", "State2", "Canada");
        Customer customer2 = new Customer("Customer2", address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Product3", 3, 20, 3));

        Console.WriteLine(order2.GeneratePackingLabel());
        Console.WriteLine(order2.GenerateShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost()}");
    }
}
