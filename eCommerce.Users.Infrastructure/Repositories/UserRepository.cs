using eCommerce.Users.Core.Dtos;
using eCommerce.Users.Core.Entities;
using eCommerce.Users.Core.RepositoryContracts;

namespace eCommerce.Users.Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    public async Task<ApplicationUser?> AddUserAsync(ApplicationUser user)
    {
        user.Id = Guid.NewGuid();

        return user;
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPasswordAsync(string? email, string? password)
    {
        return new ApplicationUser()
        {
            Id = Guid.NewGuid(),
            Email = email,
            Password = password,
            Name = "Test User",
            Gender = nameof(GenderOptions.Male),
        };
    }
}