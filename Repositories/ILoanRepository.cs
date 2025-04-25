using BankLoans.Models;

namespace BankLoans.Repositories;
public interface ILoanRepository
{
    Task<Loan> CreateLoanAsync(Loan loan);
    Task<Loan> GetLoanByIdAsync(Guid id);
    Task<IEnumerable<Loan>> GetAllLoansAsync();
    Task<Loan> UpdateLoanStatusAsync(Guid id, LoanStatus status);
}
