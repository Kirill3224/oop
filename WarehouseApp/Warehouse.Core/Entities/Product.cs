
namespace Warehouse.Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public int CategoryId { get; set; }

    public override string ToString()
    {
        return $"{Name} ({Brand}) - {Price} грн. [К-сть: {Quantity}]";
    }
}