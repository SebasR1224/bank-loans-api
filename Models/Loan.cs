namespace BankLoans.Models;
public class Loan
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public string CustomerName { get; set; }
    public string Email { get; set; }
    public DateTime CreatedAt { get; set; }
    public LoanStatus Status { get; set; }

    private Loan(Guid id, decimal amount, string customerName, string email, DateTime createdAt, LoanStatus status)
    {
        Id = id;
        Amount = amount;
        CustomerName = customerName;
        Email = email;
        CreatedAt = createdAt;
        Status = status;
    }

    public static Loan Create(Guid id, decimal amount, string customerName, string email)
    {
        return new Loan(id, amount, customerName, email, DateTime.UtcNow, LoanStatus.Pending);
    }
}

public enum LoanStatus
{
    Pending,
    Approved,
    Rejected,
    Cancelled
}
