using BankLoans.DTOs;
using BankLoans.Models;
using BankLoans.Repositories;

namespace BankLoans.Services;
public class LoanService(ILoanRepository loanRepository) : ILoanService
{

    public async Task<Loan> CreateLoanAsync(LoanRequest request)
    {
        var loan = Loan.Create(Guid.NewGuid(), request.Amount, request.CustomerName, request.Email);
        return await loanRepository.CreateLoanAsync(loan);
    }

    public async Task<Loan> GetLoanByIdAsync(Guid id)
    {
        return await loanRepository.GetLoanByIdAsync(id);
    }

    public async Task<IEnumerable<Loan>> GetLoansByCustomerEmailAsync(string customerEmail)
    {
        return await loanRepository.GetLoansByCustomerEmailAsync(customerEmail);
    }

    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await loanRepository.GetAllLoansAsync();
    }

    public async Task<Loan> UpdateLoanStatusAsync(Guid id, LoanStatus status)
    {
        return await loanRepository.UpdateLoanStatusAsync(id, status);
    }
}
