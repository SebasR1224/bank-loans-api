using BankLoans.DTOs;
using BankLoans.Models;
using BankLoans.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankLoans.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class LoanController(ILoanService loanService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var response = await loanService.GetAllLoansAsync();
        var loanResponse = response.Select(loan => new LoanResponse(loan.Id, loan.Amount, loan.CustomerName, loan.Email, loan.CreatedAt, loan.Status.ToString())).ToList();
        return Ok(loanResponse);
    }

    [HttpPost]
    public async Task<IActionResult> Apply([FromBody] LoanRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await loanService.CreateLoanAsync(request);

        var loanResponse = new LoanResponse(response.Id, response.Amount, response.CustomerName, response.Email, response.CreatedAt, response.Status.ToString());
        return Ok(loanResponse);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await loanService.GetLoanByIdAsync(id);
        var loanResponse = new LoanResponse(response.Id, response.Amount, response.CustomerName, response.Email, response.CreatedAt, response.Status.ToString());
        return Ok(loanResponse);
    }

    [HttpGet("customer/{customerEmail}")]
    public async Task<IActionResult> GetLoansByCustomerEmail([FromRoute] string customerEmail)
    {
        var response = await loanService.GetLoansByCustomerEmailAsync(customerEmail);
        var loanResponse = response.Select(loan => new LoanResponse(loan.Id, loan.Amount, loan.CustomerName, loan.Email, loan.CreatedAt, loan.Status.ToString())).ToList();
        return Ok(loanResponse);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] LoanStatusRequest request)
    {
        var response = await loanService.UpdateLoanStatusAsync(id, Enum.Parse<LoanStatus>(request.Status));
        var loanResponse = new LoanResponse(response.Id, response.Amount, response.CustomerName, response.Email, response.CreatedAt, response.Status.ToString());
        return Ok(loanResponse);
    }
}

