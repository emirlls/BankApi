using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BankManagement.Configurations.Entities;

public class CardConfiguration:IEntityTypeConfiguration<Card>
{
    public void Configure(EntityTypeBuilder<Card> builder)
    {
        builder.ToTable(builder.GetTableName(),BankManagementDatabaseConstants.SchemaName);
        builder.ConfigureByConvention();
        
        
        builder.HasOne(x => x.Accounts)
            .WithMany(x=>x.Cards)
            .HasForeignKey(x => x.AccountId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(x => x.CardTypes)
            .WithMany(x=>x.Cards)
            .HasForeignKey(x => x.CardTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IsActive).HasDefaultValue(true);
    }
}