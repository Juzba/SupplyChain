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
            await SeedUserRolesAsync(context);

            await SeedCategoriesAsync(context);
            await SeedProductsAsync(context);
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
        await context.SaveChangesAsync();
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
        await context.SaveChangesAsync();
    }

    private static async Task SeedUserRolesAsync(ApplicationDbContext context)
    {

        var user = await context.Users.FirstOrDefaultAsync(p => p.NormalizedUserName == "JUZBA@GMAIL.COM");
        var role = await context.Roles.FirstOrDefaultAsync(p => p.NormalizedName == "ADMIN");

        if (user != null && role != null)
        {
            await context.UserRoles.AddAsync(new() { UserId = user.Id, RoleId = role.Id });
            await context.SaveChangesAsync();
        }
    }



    private static async Task SeedCategoriesAsync(ApplicationDbContext context)
    {
        List<Category> categories = [
            new(){
                 Name = "NoteBooky",
                 Description = "Elektronika"
            },
            new(){
                 Name = "Pračky",
                 Description = "Elektronika"
            },
            new(){
                 Name = "Sušičky",
                 Description = "Elektronika"
            },
            new(){
                 Name = "Vysavače",
                 Description = "Elektronika"
            },
            new(){
                 Name = "Sporáky",
                 Description = "Elektronika"
            }
            ];

        await context.AddRangeAsync(categories);
        await context.SaveChangesAsync();
    }


    private static async Task SeedProductsAsync(ApplicationDbContext context)
    {
        List<Product> products = [
            new(){
                 SKU="ABC-123",
                 Name = "Apple MacBook Air 13",
                 CategoryId = context.Categories.FirstOrDefault(p=> p.Name == "NoteBooky" )!.Id,
                 UnitPrice = 27355,
                 MinStockLevel = 5,
                 IsActive = true,
                 BarCode = "1252-5541-1511",
                 Weight = 3.525M,
                 Unit = "Kg"
            },
            new(){
                 SKU="DEF-123",
                 Name = "Dell Vostro 3530",
                 CategoryId = context.Categories.FirstOrDefault(p=> p.Name == "NoteBooky" )!.Id,
                 UnitPrice = 17545,
                 MinStockLevel = 5,
                 IsActive = true,
                 BarCode = "7854-5541-9856",
                 Weight = 4.225M,
                 Unit = "Kg"
            },
            new(){
                 SKU="GHI-123",
                 Name = "Asus Vivobook 15",
                 CategoryId = context.Categories.FirstOrDefault(p=> p.Name == "NoteBooky" )!.Id,
                 UnitPrice = 13952,
                 MinStockLevel = 5,
                 IsActive = true,
                 BarCode = "9925-5541-1369",
                 Weight = 3.985M,
                 Unit = "Kg"
            },
            new(){
                 SKU="ABC-456",
                 Name = "AEG LFR71862BC",
                 CategoryId = context.Categories.FirstOrDefault(p=> p.Name == "Pračky" )!.Id,
                 UnitPrice = 9279,
                 MinStockLevel = 3,
                 IsActive = true,
                 BarCode = "4123-5541-8780",
                 Weight = 75.5M,
                 Unit = "Kg"
            },
            new(){
                 SKU="ADC-123",
                 Name = "Miele WEA 135 WCS",
                 CategoryId = context.Categories.FirstOrDefault(p=> p.Name == "Pračky" )!.Id,
                 UnitPrice = 22995,
                 MinStockLevel = 3,
                 IsActive = true,
                 BarCode = "7254-5541-5582",
                 Weight = 82.5M,
                 Unit = "Kg"
            }
            ];

        await context.AddRangeAsync(products);
        await context.SaveChangesAsync();
    }
}
