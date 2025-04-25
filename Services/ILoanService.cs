using BankLoans.DTOs;
using BankLoans.Models;

namespace BankLoans.Services;
public interface ILoanService
{
    Task<Loan> CreateLoanAsync(LoanRequest request);
    Task<Loan> GetLoanByIdAsync(Guid id);
    Task<IEnumerable<Loan>> GetAllLoansAsync();
    Task<Loan> UpdateLoanStatusAsync(Guid id, LoanStatus status);
}
