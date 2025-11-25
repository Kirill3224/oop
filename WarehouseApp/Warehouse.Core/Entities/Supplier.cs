namespace Warehouse.Core.Entities;

public class Supplier : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public override string ToString()
    {
        return $"{FullName} ({Phone})";
    }
}