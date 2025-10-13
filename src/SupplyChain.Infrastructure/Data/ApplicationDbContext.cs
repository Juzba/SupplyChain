using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupplyChain.Core.Entities;

namespace SupplyChain.Infrastructure.Data;


public interface IApplicationDbContext
{






}


public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>, IApplicationDbContext
{
    private readonly bool _isSeedEnabled;

    public ApplicationDbContext(DbContextOptions options, bool isSeedEnabled = true) : base(options)
    {
        _isSeedEnabled = isSeedEnabled;
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
    public DbSet<PurchaseOrderLine> PurchaseOrderLines { get; set; }
    public DbSet<StockLevel> StockLevels { get; set; }
    public DbSet<StockMovement> StockMovements { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
 

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (_isSeedEnabled)
        {
            // seed
        }

       

        base.OnModelCreating(modelBuilder);
    }
}
