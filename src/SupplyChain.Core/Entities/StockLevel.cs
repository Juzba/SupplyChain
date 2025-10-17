namespace SupplyChain.Core.Entities;

public class StockLevel
{
    public int ProductId { get; set; }
    public Product Product { get; set; } = new();
    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = new();


    public int AvailableQuantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int IncomingQuantity { get; set; }
    public int FreeQuantity => AvailableQuantity - ReservedQuantity;


}
