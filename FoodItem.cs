using System;

public class FoodItem
{
    public string Name { get; set; }
    public string Category { get; set; }
    public int Quantity { get; set; }
    public DateTime ExpirationDate { get; set; }

    public FoodItem(string name, string category, int quantity, DateTime expirationDate)
    {
        Name = name;
        Category = category;
        Quantity = quantity > 0 ? quantity : throw new ArgumentException("Quantity must be positive.");
        ExpirationDate = expirationDate;
    }

    public override string ToString()
    {
        return $"{Name} ({Category}) - {Quantity} units - Expiration Date: {ExpirationDate:MM/dd/yyyy}";
    }
}
