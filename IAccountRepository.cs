using BankModule.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BankModule.RepositoryInterfaces
{
    public interface IAccountRepository:IRepository<Account,Guid>
    {
        Task<Account> AddCustomerAccount(Account account, Customer customer);

        Task<Account> checkAccountNumber(string account_Number);

        Task<Guid> GetAccountId(string accountNumber);

        Task<Account> checkIban(string iban);

        Task<decimal> getAmount(string recipient_Number);

        Task<bool> accountIsActive(string account_Number);

        Task UpdateAccountActivity(string account_Number, bool isActive);

        //Task <Account> getAccountByIban(string iban);
    }
}
