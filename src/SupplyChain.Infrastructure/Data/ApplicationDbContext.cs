using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SupplyChain.Core.Entities;

namespace SupplyChain.Infrastructure.Data;


public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
{
    private readonly bool _isSeedEnabled;

    public ApplicationDbContext(DbContextOptions options, bool isSeedEnabled = true) : base(options)
    {
        _isSeedEnabled = isSeedEnabled;
    }

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


        // cascade delete

        modelBuilder.Entity<PurchaseOrder>()
            .HasMany(p => p.PurchaseOrderLines)
            .WithOne(p => p.PurchaseOrder)
            .HasForeignKey(p => p.PurchaseOrderId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Warehouse>()
            .HasMany(p => p.StockLevels)
            .WithOne(p => p.Warehouse)
            .HasForeignKey(p => p.WarehouseId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Product>()
            .HasMany(p => p.StockLevels)
            .WithOne(p => p.Product)
            .HasForeignKey(p => p.ProductId)
            .OnDelete(DeleteBehavior.Cascade);


        // StockLevel Key
        modelBuilder.Entity<StockLevel>()
            .HasOne(sl => sl.Product)
            .WithMany(p => p.StockLevels)
            .HasForeignKey(sl => sl.ProductId);

        modelBuilder.Entity<StockLevel>()
            .HasOne(sl => sl.Warehouse)
            .WithMany(w => w.StockLevels)
            .HasForeignKey(sl => sl.WarehouseId);

        modelBuilder.Entity<StockLevel>()
            .HasKey(sl => new { sl.ProductId, sl.WarehouseId });

        // Application User
        modelBuilder.Entity<ApplicationUser>()
            .HasMany(p => p.ManagedSuppliers)
            .WithOne(p => p.ManagedBy)
            .HasForeignKey(p => p.ManagedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(p => p.RequestedPurchaseOrders)
            .WithOne(p => p.RequestedBy)
            .HasForeignKey(p => p.RequestedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(p => p.ApprovedPurchaseOrders)
            .WithOne(p => p.ApprovedBy)
            .HasForeignKey(p => p.ApprovedById)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ApplicationUser>()
            .HasMany(p => p.CreatedStockMovements)
            .WithOne(p => p.CreatedBy)
            .HasForeignKey(p => p.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);


        // decimal settings
        modelBuilder.Entity<Product>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<Product>()
            .Property(p => p.Weight)
            .HasPrecision(18, 2);

        modelBuilder.Entity<PurchaseOrderLine>()
            .Property(p => p.LineTotal)
            .HasPrecision(18, 2);

        modelBuilder.Entity<PurchaseOrderLine>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);

        modelBuilder.Entity<StockMovement>()
            .Property(p => p.UnitPrice)
            .HasPrecision(18, 2);








        base.OnModelCreating(modelBuilder);
    }
}
