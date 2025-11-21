using System;
using System.Collections.Generic;

class Program
{
    public static Random rng = new Random();

    static void Main()
    {
        Wallet wallet = new Wallet(100);
        Case csgoCase = CreateDefaultCase();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== OTWIERANIE SKRZYNEK ===");
            Console.WriteLine($"Twoje saldo: {wallet.Money} zł");
            Console.WriteLine("1. Kup i otwórz skrzynkę (10 zł)");
            Console.WriteLine("2. Wyjście");
            Console.Write("Wybór: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                if (wallet.Pay(10))
                {
                    Item won = csgoCase.Open();
                    Console.WriteLine($"\nWygrałeś: {won.Name} [{won.Rarity}]");
                }
                else
                {
                    Console.WriteLine("Nie masz wystarczająco pieniędzy!");
                }

                Console.WriteLine("ENTER aby kontynuować.");
                Console.ReadLine();
            }
            else if (choice == "2")
            {
                break;
            }
        }
    }

    static Case CreateDefaultCase()
    {
        return new Case(new List<Item>()
{
new Item("MP9 | Deadly Poison", "Common", 70),
new Item("AK-47 | Elite Build", "Uncommon", 20),
new Item("AWP | Fever Dream", "Rare", 8),
new Item("M4A1-S | Golden Coil", "Epic", 1.8),
new Item("Karambit | Doppler", "Legendary", 0.2),
});
    }
}

class Wallet
{
    public double Money { get; private set; }

    public Wallet(double start)
    {
        Money = start;
    }

    public bool Pay(double amount)
    {
        if (Money >= amount)
        {
            Money -= amount;
            return true;
        }
        return false;
    }
}

class Item
{
    public string Name { get; }
    public string Rarity { get; }
    public double Chance { get; }

    public Item(string name, string rarity, double chance)
    {
        Name = name;
        Rarity = rarity;
        Chance = chance;
    }
}

class Case
{
    private List<Item> items;

    public Case(List<Item> items)
    {
        this.items = items;
    }

    public Item Open()
    {
        double roll = Program.rng.NextDouble() * 100;
        double current = 0;

        foreach (var item in items)
        {
            current += item.Chance;
            if (roll <= current)
            {
                return item;
            }
        }

        return items[items.Count - 1];
    }
}
