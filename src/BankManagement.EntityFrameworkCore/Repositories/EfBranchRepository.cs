using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Entities;
using BankManagement.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.Repositories;

public class EfBranchRepository : EfCoreRepository<BankManagementDbContext, Branch>, IBranchRepository
{
    public EfBranchRepository(IDbContextProvider<BankManagementDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task<List<Branch>> GetListAllAsync(CancellationToken cancellationToken)
    {
        var dbSet = await GetDbSetAsync();
        return await dbSet
            .Include(x => x.BranchType)
            .Include(x => x.BranchMapFeatures)
            .ToListAsync(cancellationToken);
    }
}