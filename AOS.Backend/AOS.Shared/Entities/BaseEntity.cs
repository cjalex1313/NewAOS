namespace AOS.Shared.Entities;

public class BaseEntity
{
    public DateTime CreatedDate { get; set; }
    public required string CreatedBy { get; set; }
    public DateTime ModifiedDate { get; set; }
    public required string ModifiedBy { get; set; }
}
