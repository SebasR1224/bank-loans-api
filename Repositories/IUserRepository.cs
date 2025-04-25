using BankLoans.Models;

namespace BankLoans.Repositories;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
}

