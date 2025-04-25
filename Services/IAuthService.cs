using System.Threading.Tasks;
using BankLoans.Models;

namespace BankLoans.Services
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string email, string password);
        string GenerateJwtToken(User user);
    }
}
