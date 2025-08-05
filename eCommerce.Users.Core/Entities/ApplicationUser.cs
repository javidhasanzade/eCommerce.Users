namespace eCommerce.Users.Core.Entities;

/// <summary>
/// Define the ApplicationUser class which acts as an entity model class to store user details in the data store
/// </summary>
public class ApplicationUser
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public string? Gender { get; set; }
}