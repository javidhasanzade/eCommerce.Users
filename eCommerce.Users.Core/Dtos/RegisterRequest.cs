namespace eCommerce.Users.Core.Dtos;

public record RegisterRequest(string? Email, string? Password, string? Name, GenderOptions Gender);