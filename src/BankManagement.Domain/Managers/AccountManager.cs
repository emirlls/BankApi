using System;
using BankManagement.Entities;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class AccountManager : DomainService
{

    public AccountManager()
    {
    }

    public Account Create(
        Guid customerId, 
        Guid accountTypeId, 
        string iban, 
        float balance, 
        bool isAvailable
        )
    {
        return new Account(GuidGenerator.Create(),CurrentTenant.Id,DateTime.Now)
        {
            CustomerId = customerId,
            Iban = iban,
            AccountTypeId = accountTypeId,
            Balance = balance,
            IsAvailable = isAvailable
        };
    }
    
    
    public Account Update(
        Account account,
        Guid accountTypeId,
        string iban,
        bool isAvailable,
        float balance
    )
    {
        account.Iban = iban;
        account.AccountTypeId = accountTypeId;
        account.IsAvailable = isAvailable;
        account.Balance = balance;
        return account;
    }

}