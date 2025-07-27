using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Branches;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface IBranchService : IApplicationService
{
    public Task<List<BranchDto>> GetListAllAsync(CancellationToken cancellationToken);
    public Task<bool> CreateAsync(BranchCreateDto branchCreateDto, CancellationToken cancellationToken);
    public Task<bool> UpdateAsync(Guid id, BranchUpdateDto branchUpdateDto, CancellationToken cancellationToken);
    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}