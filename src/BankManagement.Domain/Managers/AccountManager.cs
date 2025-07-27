using System;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Models.Accounts;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Managers;

public class AccountManager : ExtendedManager<Account, IAccountRepository>
{
    public AccountManager(
        IAccountRepository repository,
        IStringLocalizer<BankManagementResource> stringLocalizer
        ) : base(
        repository,
        stringLocalizer,
        AccountExceptionCodes.NotFound
        )
    {
    }

    public Account Create(
        AccountCreateModel accountCreateModel
    )
    {
        return new Account(GuidGenerator.Create(), CurrentTenant.Id, DateTime.Now)
        {
            CustomerId = accountCreateModel.CustomerId,
            Iban = accountCreateModel.Iban,
            AccountTypeId = accountCreateModel.AccountTypeId,
            Balance = accountCreateModel.Balance,
            IsAvailable = accountCreateModel.IsAvailable
        };
    }


    public Account Update(
        Account account,
        AccountUpdateModel accountUpdateModel
    )
    {
        account.CustomerId = accountUpdateModel.CustomerId;
        account.Iban = accountUpdateModel.Iban;
        account.AccountTypeId = accountUpdateModel.AccountTypeId;
        account.IsAvailable = accountUpdateModel.IsAvailable;
        account.Balance = accountUpdateModel.Balance;
        return account;
    }
}