using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SupplyChain.Core.Entities;

namespace SupplyChain.Infrastructure.Data;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        using var context = new ApplicationDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

        if (context.Database.IsRelational() && !context.Users.Any())
        {
            await SeedUsersAsync(context);
            await SeedRolesAsync(context);
            await context.SaveChangesAsync();

            await SeedUserRolesAsync(context);
            await context.SaveChangesAsync();
        }
    }


    private static async Task SeedUsersAsync(ApplicationDbContext context)
    {
        List<ApplicationUser> users = [
                new()
                {
                    UserName = "Juzba@gmail.com",
                    NormalizedUserName = "JUZBA@GMAIL.COM",
                    Email = "Juzba@gmail.com",
                    NormalizedEmail = "JUZBA@GMAIL.COM",
                    EmailConfirmed = true,
                    CreatedAt = DateTime.UtcNow,
                    PasswordHash = "AQAAAAIAAYagAAAAENWWX83DyCwFCfaTly2vSO4CFR2DkjkM8Grc+FFcnNaSvUli+Mg4QLmNbBpbZ08O4Q==",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
            ];

        await context.Users.AddRangeAsync(users);
    }


    private static async Task SeedRolesAsync(ApplicationDbContext context)
    {
        List<IdentityRole<int>> roles = [
            new()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            },
            new()
            {
                Name = "Manager",
                NormalizedName = "MANAGER",
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }
            ];

        await context.Roles.AddRangeAsync(roles);
    }

    private static async Task SeedUserRolesAsync(ApplicationDbContext context)
    {
        
        var user = await context.Users.FirstOrDefaultAsync(p => p.NormalizedUserName == "JUZBA@GMAIL.COM");
        var role = await context.Roles.FirstOrDefaultAsync(p => p.NormalizedName == "ADMIN");

        if (user != null && role != null)
        {
            await context.UserRoles.AddAsync(new() { UserId = user.Id, RoleId = role.Id });
        }
    }
}
