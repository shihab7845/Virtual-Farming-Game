using System;
using System.Collections.Generic;

class Program
{
    // First step done
    private class Player
    {
        string name;
        double balance;
        double initialLandOwned;

        // Regular constructor
        public Player(string Name, double Balance, double InitialLandOwned)
        {
            name = Name;
            balance = Balance;
            initialLandOwned = InitialLandOwned;
        }

        // Copy constructor
        public Player(Player other)
        {
            name = other.name;
            balance = other.balance;
            initialLandOwned = other.initialLandOwned;
        }

        // Sell land
        public void SellLand(double landAreaToSell, double price)
        {
            initialLandOwned -= landAreaToSell;
            balance += price;
            Console.WriteLine($"Current area of land owned: {initialLandOwned} and current balance: {balance}");
        }

        // Buy land
        public void BuyLand(double landAreaToBuy, double price)
        {
            initialLandOwned += landAreaToBuy;
            balance -= price;
            Console.WriteLine($"Current area of land owned: {initialLandOwned} and current balance: {balance}");
        }

        // Method to display player details
        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {name}, Balance: {balance}, Initial Land Owned: {initialLandOwned}");
        }
    }

    // Abstract class for animals to demonstrate inheritance and virtual methods
    public abstract class Animal
    {
        public string Name { get; set; }
        public abstract void Produce(); // Virtual method for animal production

        // Constructor
        public Animal(string name)
        {
            Name = name;
        }
    }

    // Cow class inherits from Animal
    public class Cow : Animal
    {
        public Cow(string name) : base(name) { }

        public override void Produce()
        {
            Console.WriteLine($"{Name} produces milk, beef, and leather.");
        }

        // Overloading Produce method for different products
        public void Produce(string product)
        {
            if (product == "milk")
                Console.WriteLine($"{Name} produces milk.");
            else if (product == "beef")
                Console.WriteLine($"{Name} produces beef.");
            else if (product == "leather")
                Console.WriteLine($"{Name} produces leather.");
        }
    }

    // Chicken class inherits from Animal
    public class Chicken : Animal
    {
        public Chicken(string name) : base(name) { }

        public override void Produce()
        {
            Console.WriteLine($"{Name} produces eggs.");
        }
    }

    // Sheep class inherits from Animal
    public class Sheep : Animal
    {
        public Sheep(string name) : base(name) { }

        public override void Produce()
        {
            Console.WriteLine($"{Name} produces mutton and wool.");
        }
    }

    // Dog class, does not inherit from Animal, optional for protection
    public class Dog
    {
        public string Name { get; set; }

        public Dog(string name)
        {
            Name = name;
        }

        public void ProtectFarm()
        {
            Console.WriteLine($"{Name} is protecting the farm.");
        }
    }

    // Wheat class to represent crops
    public class Wheat
    {
        public string CropName { get; set; }
        public int Quantity { get; set; }

        // Constructor
        public Wheat(string cropName, int quantity)
        {
            CropName = cropName;
            Quantity = quantity;
        }

        // Method to harvest
        public void Harvest()
        {
            Console.WriteLine($"Harvested {Quantity} of {CropName}.");
        }
    }

    // Item class for tools or consumables
    public class Item
    {
        public string Name { get; set; }

        // Constructor
        public Item(string name)
        {
            Name = name;
        }

        // Static method for using an item
        public static void UseItem(Item item)
        {
            Console.WriteLine($"Used {item.Name}.");
        }
    }

    // Inventory class to manage items and products
    public class Inventory
    {
        private List<Item> items; // List of items

        public Inventory()
        {
            items = new List<Item>();
        }

        // Method to add items to the inventory
        public void AddItem(Item item)
        {
            if (items.Count < 10)
            {
                items.Add(item);
                Console.WriteLine($"Added {item.Name} to inventory.");
            }
            else
            {
                Console.WriteLine("Inventory is full, cannot add more items.");
            }
        }

        // Method to display inventory items
        public void ShowInventory()
        {
            Console.WriteLine("Inventory:");
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    public static void Main(string[] args)
    {
        // Create Player objects
        Player myPlayer = new Player("Himu", 1000, 4);
        Player myPlayer1 = new Player(myPlayer); // Using copy constructor

        // Display Player details
        myPlayer.DisplayInfo();
        myPlayer1.DisplayInfo();

        // Demonstrating Animal and overridden Produce method
        Animal myCow = new Cow("Bessie");
        Animal myChicken = new Chicken("Cluckster");

        myCow.Produce(); // Calling the overridden Produce method
        myChicken.Produce(); // Calling the overridden Produce method

        // Demonstrating method overloading for Produce in Cow
        Cow mySpecificCow = new Cow("Daisy");
        mySpecificCow.Produce("milk"); // Overloaded method
        mySpecificCow.Produce("beef"); // Overloaded method

        // Creating and managing inventory
        Inventory myInventory = new Inventory();
        Item shovel = new Item("Shovel");
        myInventory.AddItem(shovel);
        myInventory.ShowInventory();

        // Selling and buying land
        myPlayer.SellLand(1.5, 200);
        myPlayer.BuyLand(2.0, 500);
    }
}
