namespace Warehouse.Core.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public override string ToString()
    {
        return Name;
    }
}
