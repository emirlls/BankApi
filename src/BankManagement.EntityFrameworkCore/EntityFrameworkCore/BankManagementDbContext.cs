using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.EntityFrameworkCore;

[ConnectionStringName(BankManagementDbProperties.ConnectionStringName)]
public class BankManagementDbContext : AbpDbContext<BankManagementDbContext>, IBankManagementDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public BankManagementDbContext(DbContextOptions<BankManagementDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureBankManagement();
    }
}
