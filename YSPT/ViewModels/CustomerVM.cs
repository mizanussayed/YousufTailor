using YSPT.Entities;

namespace YSPT.ViewModels;

public sealed class CustomerVM : Base
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string Mobile { get; set; } = string.Empty;
}