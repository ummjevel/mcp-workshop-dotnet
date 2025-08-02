
using System;
using System.Threading.Tasks;

namespace MyMonkeyApp;

public class Program
{
    private static readonly string[] AsciiArts = new[]
    {
        @"  (o.o)   ",
        @" (:'')>   ",
        @"  ( : )   ",
        @"  ("""")   ",
        @"  (o_O)   ",
        @"  ( ^.^)  ",
        @"  ('.')   ",
        @"  (¬_¬)   "
    };

    public static async Task Main(string[] args)
    {
        var random = new Random();
        while (true)
        {
            Console.Clear();
            // Display random ASCII art
            Console.WriteLine(AsciiArts[random.Next(AsciiArts.Length)]);
            Console.WriteLine("\nWelcome to the Monkey App!\n");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("\nSelect an option: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    var monkeys = await MonkeyHelper.GetMonkeysAsync();
                    Console.WriteLine("| Name      | Location                | Population |");
                    Console.WriteLine("|-----------|-------------------------|------------|");
                    foreach (var monkey in monkeys)
                    {
                        Console.WriteLine($"| {monkey.Name,-9} | {monkey.Location,-23} | {monkey.Population,10} |");
                    }
                    break;
                case "2":
                    Console.Write("Enter monkey name: ");
                    var name = Console.ReadLine();
                    var found = await MonkeyHelper.GetMonkeyByNameAsync(name ?? string.Empty);
                    if (found != null)
                    {
                        Console.WriteLine($"\nName: {found.Name}\nLocation: {found.Location}\nPopulation: {found.Population}");
                    }
                    else
                    {
                        Console.WriteLine("Monkey not found.");
                    }
                    break;
                case "3":
                    var randomMonkey = await MonkeyHelper.GetRandomMonkeyAsync();
                    if (randomMonkey != null)
                    {
                        Console.WriteLine($"\nRandom Monkey: {randomMonkey.Name}\nLocation: {randomMonkey.Location}\nPopulation: {randomMonkey.Population}");
                        Console.WriteLine($"(Random monkey accessed {MonkeyHelper.GetRandomMonkeyAccessCount()} times)");
                    }
                    else
                    {
                        Console.WriteLine("No monkeys available.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
