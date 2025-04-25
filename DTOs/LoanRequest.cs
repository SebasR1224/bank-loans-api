using System.ComponentModel.DataAnnotations;
namespace BankLoans.DTOs;

public record LoanRequest(
    [Required(ErrorMessage = "Loan amount is required")]
        [Range(1000, 1000000, ErrorMessage = "Amount must be between 1,000 and 1,000,000")]
        decimal Amount,

    [Required(ErrorMessage = "Customer name is required")]
        string CustomerName,

    [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        string Email
);