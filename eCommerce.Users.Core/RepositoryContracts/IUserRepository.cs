using eCommerce.Users.Core.Entities;

namespace eCommerce.Users.Core.RepositoryContracts;

/// <summary>
/// Contract to be implemented by UserRepository that contains data access logic of Users data store.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Method to add a user to the data store and return the added user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUserAsync(ApplicationUser user);
    
    /// <summary>
    /// Method to retrieve an existing user by email and password.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password);
}