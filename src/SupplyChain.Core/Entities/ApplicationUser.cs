using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable
namespace SupplyChain.Core.Entities;

public class ApplicationUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public string Department { get; set; }
    public string Position { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


    public ICollection<Supplier> ManagedSuppliers { get; set; } = [];
    public ICollection<PurchaseOrder> RequestedPurchaseOrders { get; set; } = [];
    public ICollection<PurchaseOrder> ApprovedPurchaseOrders { get; set; } = [];
    public ICollection<StockMovement> CreatedStockMovements { get; set; } = [];

}
