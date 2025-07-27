using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Entities;
using Volo.Abp.Domain.Repositories;

namespace BankManagement.Repositories;

public interface IBranchRepository : IRepository<Branch>
{
    Task<List<Branch>> GetListAllAsync(CancellationToken cancellationToken);
}