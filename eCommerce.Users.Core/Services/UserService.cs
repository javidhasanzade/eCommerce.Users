using AutoMapper;
using eCommerce.Users.Core.Dtos;
using eCommerce.Users.Core.Entities;
using eCommerce.Users.Core.RepositoryContracts;
using eCommerce.Users.Core.ServiceContracts;

namespace eCommerce.Users.Core.Services;

/// <summary>
/// Service implementation for handling user authentication and registration processes.
/// </summary>
internal class UserService(IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<AuthenticationResponse?> LoginAsync(LoginRequest loginRequest)
    {
        var user = await userRepository.GetUserByEmailAndPasswordAsync(loginRequest.Email, loginRequest.Password);
        
        if (user == null)
            return null;
        
        return mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }
    
    /// <summary>
    /// Registers a new user and returns an authentication response upon successful registration.
    /// </summary>
    /// <param name="registerRequest">The request object containing the user's registration details such as email, password, name, and gender.</param>
    /// <returns>An <see cref="AuthenticationResponse"/> containing the user details and a token if registration is successful; otherwise, null.</returns>
    public async Task<AuthenticationResponse?> RegisterAsync(RegisterRequest registerRequest)
    {
        var user = mapper.Map<ApplicationUser>(registerRequest);
        
        var userResponse = await userRepository.AddUserAsync(user);
        
        if (userResponse == null)
            return null;
        
        return mapper.Map<AuthenticationResponse>(user) with { Success = true, Token = "token" };
    }
}