using System;
using System.Collections.Generic;

namespace CalculatorFFXIV;

internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Item> items = new Dictionary<string, Item>();
        items["tincture"] = CreateItem("tincture", askQuantity: true);
        if (items["tincture"].Quantity == 0.0)
        {
        items["tincture"] = CreateItem("tincture", 1, true);
            Console.WriteLine("Tincture quantity cannot be zero.");
            return;
        }
        items["clusters"] = CreateItem("clusters", 3.0 * items["tincture"].Quantity);
        items["alchemist"] = CreateItem("alchemist", items["tincture"].Quantity);
        items["earthBreak"] = CreateItem("EarthBreak", items["tincture"].Quantity);
        items["grade5"] = CreateItem("Grade 5", 3.0 / items["tincture"].Quantity);
        items["crystal"] = CreateItem("crystal", 8.0 * items["grade5"].Quantity);
        items["water"] = CreateItem("water", 2.0 * items["grade5"].Quantity);
        items["lunatender"] = CreateItem("lunatender", items["grade5"].Quantity);
        items["sweet"] = CreateItem("sweet", 2.0 * items["grade5"].Quantity);
        foreach (KeyValuePair<string, Item> item in items)
        {
            PrintItem(item.Key, item.Value);
        }
    }

    private static Item CreateItem(string itemName, double quantity = 1, bool askQuantity = false)
    {
        // ...
    }

    private static Item CreateItem(string itemName, bool askQuantity = false)
    {
        Item item = new Item();
        if (askQuantity)
        {
            Console.WriteLine("Enter the quantity for " + itemName + ":");
            if (!double.TryParse(Console.ReadLine(), out var quantity))
            {
                Console.WriteLine("Invalid quantity. Please enter a number.");
                return null;
            }
            item.Quantity = quantity;
        }
        else
        {
            item.Quantity = 1.0;
        }
        Console.WriteLine("Enter the price for " + itemName + ":");
        if (!double.TryParse(Console.ReadLine(), out var price))
        {
            Console.WriteLine("Invalid price. Please enter a number.");
            return null;
        }
        item.Price = price;
        return item;
    }

    private static void PrintItem(string itemName, Item item)
    {
        Console.WriteLine($"{itemName} Quantity: {item.Quantity}");
        Console.WriteLine($"{itemName} Price: {item.Price}");
    }
}
