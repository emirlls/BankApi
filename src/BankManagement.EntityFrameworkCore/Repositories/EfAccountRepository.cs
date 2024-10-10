using BankManagement.Entities;
using BankManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.Repositories;

public class EfAccountRepository:EfCoreRepository<BankManagementDbContext,Account>,IAccountRepository
{
    public EfAccountRepository(IDbContextProvider<BankManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
        
    }
}