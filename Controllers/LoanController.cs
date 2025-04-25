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
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Apply([FromBody] LoanRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await loanService.CreateLoanAsync(request);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var response = await loanService.GetLoanByIdAsync(id);
        return Ok(response);
    }

    [HttpGet("customer/{customerEmail}")]
    public async Task<IActionResult> GetLoansByCustomerEmail([FromRoute] string customerEmail)
    {
        var response = await loanService.GetLoansByCustomerEmailAsync(customerEmail);
        return Ok(response);
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus([FromRoute] Guid id, [FromBody] LoanStatus status)
    {
        var response = await loanService.UpdateLoanStatusAsync(id, status);
        return Ok(response);
    }
}

