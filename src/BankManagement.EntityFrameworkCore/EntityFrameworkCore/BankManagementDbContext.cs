using BankManagement.Entities;
using BankManagement.Entities.LookUps;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement.EntityFrameworkCore;

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
    
    public DbSet<Customer> Customers { get; }
    public DbSet<Account> Accounts { get; }
    public DbSet<Card> Cards { get; }
    public DbSet<Transaction> Transactions { get; }
    
    public DbSet<AccountType> AccountTypes { get; set; }
    public DbSet<CardType> CardTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(BankManagementDbContext).
            Assembly);
        
        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();
        builder.ConfigureFeatureManagement();
        builder.ConfigureTenantManagement();
    }
}
