using BankManagement.Constants;
using BankManagement.Entities.LookUps;
using BankManagement.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BankManagement.Configurations.Lookups;

public class BranchTypeConfiguration: IEntityTypeConfiguration<BranchType>
{
    public void Configure(EntityTypeBuilder<BranchType> builder)
    {
        builder.ToTable(builder.GetTableName(),BankManagementDatabaseConstants.SchemaName);
        builder.ConfigureByConvention();
    }
}