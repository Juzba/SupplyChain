namespace SupplyChain.Core.Entities;
#nullable disable
public class StockMovement
{
    public int Id { get; set; }
    public MovementType Type { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Reference { get; set; } 


    // Application User
    public int CreatedById { get; set; }
    public ApplicationUser CreatedBy { get; set; } = new();
    public DateTime CreatedAt { get; set; }
    public string Note { get; set; } = string.Empty;


    // Product and warehouse
    public int ProductId { get; set; }
    public Product Product { get; set; } = new();

    public int WarehouseId { get; set; }
    public Warehouse Warehouse { get; set; } = new();

}

public enum MovementType
{
    In,
    Out,
    Transfer,
    Adjustment
}