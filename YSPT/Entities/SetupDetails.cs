namespace YSPT.Entities;

public class SetupDetails : Base
{
    public string Name { get; set; } = string.Empty;
    public long? ParentId {  get; set; }
}