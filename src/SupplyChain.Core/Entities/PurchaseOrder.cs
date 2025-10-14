namespace SupplyChain.Core.Entities;
# nullable disable
public class PurchaseOrder
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int SupplierId { get; set; }
    public POStatus Status { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime? ExpectedDelivery { get; set; }

    // Application User
    public int RequestedById { get; set; }
    public ApplicationUser RequestedBy { get; set; }
    public int ApprovedById { get; set; }
    public ApplicationUser ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }


    public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];
}

public enum POStatus
{
    Draft,
    Approved,
    Sent,
    Received,
    Closed
}
