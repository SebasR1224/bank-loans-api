using System.ComponentModel.DataAnnotations;
namespace BankLoans.DTOs;

public record LoanResponse(
    Guid Id,
    decimal Amount,
    string CustomerName,
    string Email,
    DateTime CreatedAt,
    string Status
);