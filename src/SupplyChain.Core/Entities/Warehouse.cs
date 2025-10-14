namespace SupplyChain.Core.Entities;
#nullable disable
public class Warehouse
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public bool IsActive { get; set; }


    public ICollection<StockLevel> StockLevels { get; set; } = [];
    public ICollection<StockMovement> StockMovements { get; set; } = [];
}
