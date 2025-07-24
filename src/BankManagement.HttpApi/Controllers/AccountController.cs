using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Attributes;
using BankManagement.Constants;
using BankManagement.Dtos.Accounts;
using BankManagement.Services;
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

    /// <summary>
    /// Used to get list of accounts
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [CacheManagement<AccountDto>(CacheModelConstants.AccountCacheModel)]
    public async Task<List<AccountDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _accountService.GetListAsync(cancellationToken);
    }
    
    /// <summary>
    /// Used to get the accounts with id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default
    )
    {
        return await _accountService.GetByIdAsync(id,cancellationToken);
    }

    /// <summary>
    /// Used to create account
    /// </summary>
    /// <param name="accountCreateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [CacheClear<AccountDto>(CacheModelConstants.AccountCacheModel)]
    public async Task<bool> CreateAsync(AccountCreateDto accountCreateDto,
        CancellationToken cancellationToken = default)
    {
        return await _accountService.CreateAsync(accountCreateDto, cancellationToken);
    }

    /// <summary>
    /// Used to update account
    /// </summary>
    /// <param name="id"></param>
    /// <param name="accountUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [CacheClear<AccountDto>(CacheModelConstants.AccountCacheModel)]
    public async Task<bool> UpdateAsync(Guid id,AccountUpdateDto accountUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _accountService.UpdateAsync(id,accountUpdateDto, cancellationToken);
    }

    /// <summary>
    /// Used to delete account
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [CacheClear<AccountDto>(CacheModelConstants.AccountCacheModel)]
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _accountService.DeleteAsync(id, cancellationToken);
    }
}