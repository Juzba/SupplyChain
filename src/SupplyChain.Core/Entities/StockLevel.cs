namespace SupplyChain.Core.Entities;

public class StockLevel
{
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public int AvailableQuantity { get; set; }
    public int ReservedQuantity { get; set; }
    public int IncomingQuantity { get; set; }
    public int FreeQuantity { get; set; }
}
