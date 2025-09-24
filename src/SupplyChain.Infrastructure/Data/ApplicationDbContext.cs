using Microsoft.EntityFrameworkCore;

namespace SupplyChain.Infrastructure.Data;


public interface IApplicationDbContext
{






}


public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private bool _isSeedEnabled;

    public ApplicationDbContext(DbContextOptions options, bool isSeedEnabled = true) : base(options)
    {
        _isSeedEnabled = isSeedEnabled;
    }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        if (_isSeedEnabled)
        {
            // seed
        }

        // configurations
        //modelBuilder.ApplyConfiguration();




        base.OnModelCreating(modelBuilder);
    }







}
