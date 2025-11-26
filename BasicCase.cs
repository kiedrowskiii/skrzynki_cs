using System;

public class BasicCase : ICase
{
    private static readonly string[] items = { "Blue Skin", "Purple Skin", "Pink Skin", "Red Skin", "Knife" };
    private static readonly Random rng = new Random();

    public string Open()
    {
        int roll = rng.Next(items.Length);
        return items[roll];
    }
}
