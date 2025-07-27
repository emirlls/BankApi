using BankManagement.Entities;
using BankManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.Repositories;

public class EfBranchMapFeatureRepository : EfCoreRepository<BankManagementDbContext, BranchMapFeature>,
    IBranchMapFeatureRepository
{
    public EfBranchMapFeatureRepository(IDbContextProvider<BankManagementDbContext> dbContextProvider) : base(
        dbContextProvider)
    {
    }
}