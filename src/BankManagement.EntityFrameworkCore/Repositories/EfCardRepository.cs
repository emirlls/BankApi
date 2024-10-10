using BankManagement.Entities;
using BankManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.Repositories;

public class EfCardRepository:EfCoreRepository<BankManagementDbContext,Card>,ICardRepository
{
    public EfCardRepository(IDbContextProvider<BankManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}