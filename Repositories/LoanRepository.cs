using BankLoans.Models;

namespace BankLoans.Repositories;
public class LoanRepository : ILoanRepository
{
    private readonly List<Loan> _loans = new();

    public async Task<IEnumerable<Loan>> GetAllLoansAsync()
    {
        return await Task.FromResult(_loans.AsEnumerable());
    }

    public async Task<Loan> CreateLoanAsync(Loan loan)
    {
        await Task.Delay(1000);

        _loans.Add(loan);
        return loan;
    }

    public async Task<IEnumerable<Loan>> GetLoansByCustomerEmailAsync(string customerEmail)
    {
        await Task.Delay(1000);
        return _loans.Where(l => l.Email == customerEmail);
    }

    public async Task<Loan> GetLoanByIdAsync(Guid id)
    {
        await Task.Delay(1000);
        return _loans.FirstOrDefault(l => l.Id == id);
    }

    public async Task<Loan> UpdateLoanStatusAsync(Guid id, LoanStatus status)
    {
        await Task.Delay(1000);
        var loan = _loans.FirstOrDefault(l => l.Id == id);
        loan.Status = status;
        return loan;
    }
}
