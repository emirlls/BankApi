using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using BankModule.Entities;

namespace BankModule.RepositoryInterfaces
{
    public interface ITransactionRepository:IRepository<Transaction,Guid>
    {
        Task<Transaction> AddTransaction(Transaction transaction);

    }
}
