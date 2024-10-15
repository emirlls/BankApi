using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Accounts;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Interfaces;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class AccountService:ApplicationService,IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;
    private readonly ICustomerRepository _customerRepository;
    private IStringLocalizer<BankManagementResource> _stringLocalizer;
    public AccountService(IAccountRepository accountRepository, AccountManager accountManager, ICustomerRepository customerRepository, IStringLocalizer<BankManagementResource> stringLocalizer)
    {
        _accountRepository = accountRepository;
        _accountManager = accountManager;
        _customerRepository = customerRepository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<AccountDto> CreateAsync(
        AccountCreateDto accountCreateDto, 
        CancellationToken cancellationToken = default
    )
    {
        var customer = await _customerRepository.FindAsync(x => x.Id.Equals(accountCreateDto.CustomerId), cancellationToken: cancellationToken);
        if (customer == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CustomerExceptionCodes.NotFound]);
        }
        
        var account = _accountManager.Create(
            accountCreateDto.CustomerId, 
            accountCreateDto.Iban,
            accountCreateDto.AccountTypeId, 
            accountCreateDto.Balance, 
            accountCreateDto.IsAvailable);

        await _accountRepository.InsertAsync(account, true,cancellationToken: cancellationToken);
        return ObjectMapper.Map<Account, AccountDto>(account);
    }

    public async Task<AccountDto> UpdateAsync(Guid id,AccountUpdateDto accountUpdateDto, CancellationToken cancellationToken = default)
    {
        var account = await _accountRepository.FindAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (account == null)
        {
            throw new UserFriendlyException(_stringLocalizer[AccountExceptionCodes.NotFound]);
        }

        _accountManager.Update(account, accountUpdateDto.Iban, accountUpdateDto.AccountTypeId,
            accountUpdateDto.IsAvailable, accountUpdateDto.Balance);
        await _accountRepository.UpdateAsync(account, cancellationToken: cancellationToken);

        return ObjectMapper.Map<Account, AccountDto>(account);
    }

    public async Task<bool> DeleteAsync(Guid id,CancellationToken cancellationToken = default)
    {
        var account = await _accountRepository.FindAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (account == null)
        {
            throw new UserFriendlyException(_stringLocalizer[AccountExceptionCodes.NotFound]);
        }

        await _accountRepository.DeleteAsync(account, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<List<AccountDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetListAsync(x => x.IsAvailable.Equals(true), cancellationToken: cancellationToken);

        return ObjectMapper.Map<List<Account>,List<AccountDto>>(accounts);
    }

    public async Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default
    )
    {
        var account = await _accountRepository.FindAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (account == null)
        {
            throw new UserFriendlyException(_stringLocalizer[AccountExceptionCodes.NotFound]);
        }

        return ObjectMapper.Map<Account, AccountDto>(account);
    }
}