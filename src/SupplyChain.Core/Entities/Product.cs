namespace SupplyChain.Core.Entities;

#nullable disable
public class Product
{
    public int Id { get; set; }
    public string SKU { get; set; }
    public string Name { get; set; }
    public int CategoryId { get; set; }
    public decimal UnitPrice { get; set; }
    public int MinStockLevel { get; set; }
    public bool IsActive { get; set; }


    public string BarCode { get; set; }
    public decimal Weight { get; set; }
    public string Unit { get; set; }
}
