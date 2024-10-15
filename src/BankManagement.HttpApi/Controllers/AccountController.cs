using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Accounts;
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

    [HttpGet("{id}")]
    public async Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default
    )
    {
        return await _accountService.GetByIdAsync(id,cancellationToken);
    }

    [HttpPost]
    public async Task<AccountDto> CreateAsync(AccountCreateDto accountCreateDto,
        CancellationToken cancellationToken = default)
    {
        return await _accountService.CreateAsync(accountCreateDto, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<AccountDto> UpdateAsync(Guid id,AccountUpdateDto accountUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _accountService.UpdateAsync(id,accountUpdateDto, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _accountService.DeleteAsync(id, cancellationToken);
    }

    [HttpGet]
    public async Task<List<AccountDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _accountService.GetListAsync(cancellationToken);
    }
}