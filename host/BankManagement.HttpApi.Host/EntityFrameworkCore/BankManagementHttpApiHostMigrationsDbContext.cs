using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankManagement.EntityFrameworkCore;

public class BankManagementHttpApiHostMigrationsDbContext : AbpDbContext<BankManagementHttpApiHostMigrationsDbContext>
{
    public BankManagementHttpApiHostMigrationsDbContext(DbContextOptions<BankManagementHttpApiHostMigrationsDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ConfigureBankManagement();
    }
}
