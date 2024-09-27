using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.EntityFrameworkCore;

[ConnectionStringName(BankManagementDbProperties.ConnectionStringName)]
public interface IBankManagementDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
