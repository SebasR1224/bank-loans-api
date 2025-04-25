using BankLoans.Models;

namespace BankLoans.Repositories;

public class UserRepository : IUserRepository

{
    private readonly List<User> _users = [
        User.Create("user", "usuario@test.com", "123", "User"),
        User.Create("admin", "admin@test.com", "123", "Administrator")
    ];

    public Task<User> GetByEmailAsync(string email)
    {
        return Task.FromResult(_users.FirstOrDefault(u => u.Email == email));
    }
}

