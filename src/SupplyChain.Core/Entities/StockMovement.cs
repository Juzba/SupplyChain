namespace SupplyChain.Core.Entities;

public class StockMovement
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int WarehouseId { get; set; }
    public MovementType Type { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public string Reference { get; set; } = string.Empty;


    // Application User
    public int CreatedById { get; set; }
    public ApplicationUser CreatedBy { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
    public string Note { get; set; } = string.Empty;
}

public enum MovementType
{
    In,
    Out,
    Transfer,
    Adjustment
}