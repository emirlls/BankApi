using BankManagement.Entities;
using BankManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.Repositories;

public class EfTransactionRepository:EfCoreRepository<BankManagementDbContext,Transaction>,ITransactionRepository
{
    public EfTransactionRepository(IDbContextProvider<BankManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}