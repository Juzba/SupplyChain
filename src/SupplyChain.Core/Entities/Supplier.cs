namespace SupplyChain.Core.Entities;

# nullable disable
public class Supplier
{
    public int Id { get; set; }
    public string Code { get; set; }
    public string CompanyName { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhone { get; set; }
    public string Address { get; set; }
    public bool IsActive { get; set; }


    // Application User
    public int ManagedById { get; set; }
    public ApplicationUser ManagedBy { get; set; }
}
