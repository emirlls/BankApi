using BankModule.Entities;
using BankModule.EntityFrameworkCore;
using BankModule.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace BankModule.Repositories
{
    public class AccountRepository : EfCoreRepository<BankModuleDbContext, Account, Guid>, IAccountRepository
    {

        public AccountRepository(IDbContextProvider<BankModuleDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }


        public async Task<Account> AddCustomerAccount(Account account, Customer customer)
        {
            if (account == null) throw new ArgumentNullException(nameof(account));
            if (customer == null) throw new ArgumentNullException(nameof(customer));


            try
            {
        
                var dbContext = await GetDbContextAsync();
                if (dbContext == null) { throw new ArgumentNullException(nameof(dbContext)); }

                DbContext.Customers.Add(customer);
                DbContext.Accounts.Add(account);
                
                await DbContext.SaveChangesAsync();
                return account;

            }

            catch (Exception ex)
            {
                // Hata loglama
                throw new Exception($"Error adding account: {ex.Message}", ex);
            }
        }

        public async Task<Account> checkAccountNumber(string account_Number)
        {
            var result = DbContext.Accounts.FirstOrDefault(a => a.account_number == account_Number);
            return result;
        }

        public async Task<Account> checkIban(string iban)
        {
            var result = DbContext.Accounts.FirstOrDefault(a => a.iban == iban);

            return result;

        }

        public async Task<Guid> GetAccountId(string accountNumber)
        {
            var account = DbContext.Accounts.FirstOrDefault(a => a.account_number == accountNumber);
         
            return account.Id;
        }

        public async Task<decimal> getAmount(string recipient_Number)
        {
            var account = await DbContext.Accounts.FirstOrDefaultAsync(a => a.account_number == recipient_Number);
            return account.balance;
        }

        public async Task<bool> accountIsActive(string iban)
        {
            var account = await DbContext.Accounts.FirstOrDefaultAsync(a => a.iban == iban);
            return account.is_active;
        }

        public async Task UpdateAccountActivity(string account_Number, bool isActive)
        {
            var account = await DbContext.Accounts.FirstOrDefaultAsync(a => a.account_number == account_Number);
            account.is_active = isActive;
            await DbContext.SaveChangesAsync();
        }
    }
}
