namespace SupplyChain.Core.Entities;
#nullable disable
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    // Products
    public ICollection<Product> Products { get; set; } = [];
}
