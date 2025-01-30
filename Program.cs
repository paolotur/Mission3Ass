using System;
using System.Collections.Generic;

class Program
{
    static List<FoodItem> inventory = new List<FoodItem>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nFood Bank Inventory System");
            Console.WriteLine("1. Add Food Item");
            Console.WriteLine("2. Delete Food Item");
            Console.WriteLine("3. Print List of Current Food Items");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddFoodItem();
                    break;
                case "2":
                    DeleteFoodItem();
                    break;
                case "3":
                    PrintFoodItems();
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice, please enter a number between 1 and 4.");
                    break;
            }
        }
    }

    static void AddFoodItem()
    {
        Console.Write("Enter food name: ");
        string name = Console.ReadLine();

        Console.Write("Enter category (e.g., Canned Goods, Dairy, Produce): ");
        string category = Console.ReadLine();

        int quantity;
        while (true)
        {
            Console.Write("Enter quantity: ");
            if (int.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                break;
            Console.WriteLine("Invalid input. Quantity must be a positive integer.");
        }

        DateTime expirationDate;
        while (true)
        {
            Console.Write("Enter expiration date (MM/DD/YYYY): ");
            if (DateTime.TryParse(Console.ReadLine(), out expirationDate))
                break;
            Console.WriteLine("Invalid date format. Please enter a valid date (MM/DD/YYYY).");
        }

        inventory.Add(new FoodItem(name, category, quantity, expirationDate));
        Console.WriteLine("Food item added successfully.");
    }

    static void DeleteFoodItem()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No food items in inventory.");
            return;
        }

        Console.WriteLine("Select the item number to delete:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }

        int index;
        while (true)
        {
            Console.Write("Enter item number to delete: ");
            if (int.TryParse(Console.ReadLine(), out index) && index > 0 && index <= inventory.Count)
                break;
            Console.WriteLine("Invalid choice. Please enter a valid item number.");
        }

        inventory.RemoveAt(index - 1);
        Console.WriteLine("Food item deleted successfully.");
    }

    static void PrintFoodItems()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("No food items in inventory.");
            return;
        }

        Console.WriteLine("\nCurrent Food Inventory:");
        foreach (var item in inventory)
        {
            Console.WriteLine(item);
        }
    }
}
