using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BankManagement.Configurations.Entities;

public class BranchMapFeatureConfiguration : IEntityTypeConfiguration<BranchMapFeature>
{
    public void Configure(EntityTypeBuilder<BranchMapFeature> builder)
    {
        builder.ToTable(builder.GetTableName(),BankManagementDatabaseConstants.SchemaName);
        builder.ConfigureByConvention();

        builder.HasOne(x => x.Branch)
            .WithMany(x => x.BranchMapFeatures)
            .HasForeignKey(x => x.BranchId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired(false);
    }
}