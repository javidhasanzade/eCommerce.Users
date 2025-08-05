using eCommerce.Users.Core.Dtos;

namespace eCommerce.Users.Core.ServiceContracts;

/// <summary>
/// Contract for a user service that contains use cases for users.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Method to handle user login use case and
    /// returns AuthenticationResponse object that contains the status of login.
    /// </summary>
    /// <param name="loginRequest">The request object containing the user's email and password for login.</param>
    /// <returns>Returns an AuthenticationResponse object with the status and details of the login.</returns>
    Task<AuthenticationResponse?> LoginAsync(LoginRequest loginRequest);

    /// <summary>
    /// Method to handle user registration use case and
    /// returns AuthenticationResponse object that contains the status of registration.
    /// </summary>
    /// <param name="registerRequest">The request object containing user registration information such as email, password, name, and gender.</param>
    /// <returns>Returns an AuthenticationResponse object with the status and details of the registration.</returns>
    Task<AuthenticationResponse?> RegisterAsync(RegisterRequest registerRequest);
}