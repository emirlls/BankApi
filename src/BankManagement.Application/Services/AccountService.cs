using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Accounts;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Models.Accounts;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class AccountService : ApplicationService, IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly AccountManager _accountManager;
    private IStringLocalizer<BankManagementResource> _stringLocalizer;
    private readonly CustomerManager _customerManager;

    public AccountService(IAccountRepository accountRepository,
        AccountManager accountManager,
        CustomerManager customerManager,
        IStringLocalizer<BankManagementResource> stringLocalizer)
    {
        _accountRepository = accountRepository;
        _accountManager = accountManager;
        _stringLocalizer = stringLocalizer;
        _customerManager = customerManager;
    }

    public async Task<bool> CreateAsync(
        AccountCreateDto accountCreateDto,
        CancellationToken cancellationToken = default
    )
    {
        await _customerManager.TryGetByAsync(x => x.Id.Equals(accountCreateDto.CustomerId), true);
        var alreadyExistsIban = await _accountManager.TryGetByAsync(x => string.Equals(x.Iban, accountCreateDto.Iban));
        if (alreadyExistsIban != null)
        {
            throw new UserFriendlyException(_stringLocalizer[AccountExceptionCodes.Iban.AlreadyExists]);
        }

        var accountCreateModel = ObjectMapper.Map<AccountCreateDto, AccountCreateModel>(accountCreateDto);
        var account = _accountManager.Create(accountCreateModel);

        await _accountRepository.InsertAsync(account, true, cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, AccountUpdateDto accountUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var account = await _accountManager.TryGetByAsync(x => x.Id.Equals(id), true);
        var accountUpdateModel = ObjectMapper.Map<AccountUpdateDto, AccountUpdateModel>(accountUpdateDto);
        var updatedAccount = _accountManager.Update(account!, accountUpdateModel);
        await _accountRepository.UpdateAsync(updatedAccount, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var account = await _accountManager.TryGetByAsync(x => x.Id.Equals(id), true);
        await _accountRepository.DeleteAsync(account!, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<List<AccountDto>> GetListAsync(CancellationToken cancellationToken)
    {
        var accounts =
            await _accountRepository.GetListAsync(x => x.IsAvailable == true,
                cancellationToken: cancellationToken);

        return ObjectMapper.Map<List<Account>, List<AccountDto>>(accounts);
    }

    public async Task<AccountDto> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    )
    {
        var account = await _accountManager.TryGetByAsync(x => x.Id.Equals(id), true);
        return ObjectMapper.Map<Account, AccountDto>(account);
    }
}