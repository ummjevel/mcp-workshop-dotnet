using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp;

/// <summary>
/// Provides helper methods for managing monkey data from the Monkey MCP server.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey>? monkeys;
    private static int randomMonkeyAccessCount = 0;
    private static readonly object lockObj = new();

    /// <summary>
    /// Gets all monkeys from the Monkey MCP server.
    /// </summary>
    public static async Task<List<Monkey>> GetMonkeysAsync()
    {
        if (monkeys != null)
            return monkeys;

        // Example: Replace with actual MCP server call and parsing
        var mcpMonkeys = await FetchMonkeysFromMcpAsync();
        monkeys = mcpMonkeys;
        return monkeys;
    }

    /// <summary>
    /// Gets a random monkey and tracks access count.
    /// </summary>
    public static async Task<Monkey?> GetRandomMonkeyAsync()
    {
        var allMonkeys = await GetMonkeysAsync();
        if (allMonkeys.Count == 0)
            return null;
        lock (lockObj)
        {
            randomMonkeyAccessCount++;
        }
        var random = new Random();
        return allMonkeys[random.Next(allMonkeys.Count)];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    public static async Task<Monkey?> GetMonkeyByNameAsync(string name)
    {
        var allMonkeys = await GetMonkeysAsync();
        return allMonkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been accessed.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;

    private static async Task<List<Monkey>> FetchMonkeysFromMcpAsync()
    {
        // This is a placeholder for the actual MCP server integration.
        // Replace with real HTTP call and deserialization as needed.
        await Task.Delay(100); // Simulate async call
        return new List<Monkey>
        {
            new Monkey { Name = "Capuchin", Location = "Central & South America", Population = 15000 },
            new Monkey { Name = "Howler", Location = "South America", Population = 12000 },
            new Monkey { Name = "Macaque", Location = "Asia, North Africa", Population = 200000 },
            new Monkey { Name = "Mandrill", Location = "Central Africa", Population = 4000 },
            new Monkey { Name = "Tamarin", Location = "South America", Population = 2500 }
        };
    }
}
