namespace MyMonkeyApp;

/// <summary>
/// Represents a monkey species with details.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the name of the monkey species.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the geographic location of the monkey species.
    /// </summary>
    public string Location { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the estimated population of the monkey species.
    /// </summary>
    public int Population { get; set; }
}
