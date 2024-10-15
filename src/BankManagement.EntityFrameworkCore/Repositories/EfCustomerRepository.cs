using System.Threading.Tasks;
using BankManagement.Entities;
using BankManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.Repositories;

public class EfCustomerRepository:EfCoreRepository<BankManagementDbContext,Customer>,ICustomerRepository
{
    public EfCustomerRepository(IDbContextProvider<BankManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
        
    }
    
}