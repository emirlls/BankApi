using System;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
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
        var customer = await _customerRepository.GetAsync(x => x.Id.Equals(accountCreateDto.CustomerId));
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

        await _accountRepository.InsertAsync(account, cancellationToken: cancellationToken);
        return ObjectMapper.Map<Account, AccountDto>(account);
    }
    public async Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default
    )
    {
        var account = await _accountRepository.GetAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        return ObjectMapper.Map<Account, AccountDto>(account);
    }
}