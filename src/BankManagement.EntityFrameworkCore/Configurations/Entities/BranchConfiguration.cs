using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BankManagement.Configurations.Entities;

public class BranchConfiguration: IEntityTypeConfiguration<Branch>
{
    public void Configure(EntityTypeBuilder<Branch> builder)
    {
        builder.ToTable(builder.GetTableName(),BankManagementDatabaseConstants.SchemaName);
        builder.ConfigureByConvention();

        builder.HasOne(x => x.BranchType)
            .WithMany(x => x.Branches)
            .HasForeignKey(x => x.BranchTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}