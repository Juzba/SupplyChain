﻿namespace SupplyChain.Core.Entities;

public class PurchaseOrderLine
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal LineTotal { get; set; }

    public int PurchaseOrderId { get; set; }
    public PurchaseOrder PurchaseOrder { get; set; } = new();
    public int ProductId { get; set; }
    public Product Product { get; set; } = new();
}
