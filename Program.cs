using System;

class Program
{
    static void Main()
    {
        ICase basicCase = new 
        ICase statTrakCase = new StatTrakDecorator(basicCase);

        Console.WriteLine("Opening basic case:");
        Console.WriteLine(basicCase.Open());

        Console.WriteLine("\nOpening StatTrak decorated case:");
        Console.WriteLine(statTrakCase.Open());
    }
}
