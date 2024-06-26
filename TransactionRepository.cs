using BankModule.DTOs;
using BankModule.Entities;
using BankModule.EntityFrameworkCore;
using BankModule.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankModule.Repositories
{
    public class TransactionRepository: EfCoreRepository<BankModuleDbContext, Transaction, Guid>, ITransactionRepository
    {

        public TransactionRepository(IDbContextProvider<BankModuleDbContext> contextProvider) : base(contextProvider) { }

        public async Task<Transaction> AddTransaction(Transaction transaction)
        {
            //Add transaction to database
            DbContext.Transactions.Add(transaction);
            await DbContext.SaveChangesAsync();

            return transaction;
        }
            
    }
}
