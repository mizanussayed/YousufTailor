namespace YSPT.Entities;

public sealed class Customer : Base
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
}