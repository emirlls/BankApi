using System;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class AccountManager : DomainService
{

    public AccountManager()
    {
    }

    public Account Create(
        Guid customerId, 
        string iban, 
        int accountTypeId, 
        float balance, 
        bool isAvailable
        )
    {
        return new Account(GuidGenerator.Create())
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
        string iban,
        int accountTypeId,
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