namespace YSPT.Entities;

public sealed class Service : Base
{
    public long  CustomerId { get; set; }
    public long ServiceType { get; set; }
    public DateOnly DeliveryDate { get; set; }
    public long? PaidAmount { get; set; }
    public long? DueAmount { get; set; }
    public long TotalAmount { get; set; }
}