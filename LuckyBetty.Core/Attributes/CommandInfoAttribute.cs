namespace LuckyBetty.Core.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class CommandInfoAttribute : Attribute
{
    public CommandInfoAttribute(string description, string usage, string category)
    {
        Description = description;
        Usage = usage;
        Category = category;
    }

    public string Description { get; }

    public string Usage { get; }

    public string Category { get; set; }
}
