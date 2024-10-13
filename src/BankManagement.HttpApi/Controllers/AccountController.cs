using System;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers;

//[Authorize]
[ApiController]
[Route("api/bank-management/accounts")]
public class AccountController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpGet]
    public async Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default
    )
    {
        return await _accountService.GetByIdAsync(id,cancellationToken);
    }
}