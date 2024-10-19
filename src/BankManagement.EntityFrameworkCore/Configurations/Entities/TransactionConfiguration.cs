using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BankManagement.Configurations.Entities;

public class TransactionConfiguration:IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable(builder.GetTableName(),BankManagementDatabaseConstants.SchemaName);
        builder.ConfigureByConvention();
        builder.HasOne(x => x.TransactionType)
            .WithMany()
            .HasForeignKey(x => x.TransactionTypeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}