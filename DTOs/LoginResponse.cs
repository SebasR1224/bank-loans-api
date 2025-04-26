namespace BankLoans.DTOs;

public record LoginResponse(string Token, UserResponse User);

public record UserResponse(string Id, string Email, string Name, string Role);
