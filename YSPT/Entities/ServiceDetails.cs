namespace YSPT.Entities;

public sealed class ServiceDetails : Base
{
    public long ServiceId { get; set; }
    public string ServiceDescription { get; set; } = string.Empty;
}