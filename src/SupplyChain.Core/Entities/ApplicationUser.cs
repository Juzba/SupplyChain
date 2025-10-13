using Microsoft.AspNetCore.Identity;

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
}
