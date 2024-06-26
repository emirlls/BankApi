using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankModule.Entities;

namespace BankModule.Configuration
{
    public class TransactionConfiguration:IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("BankModuleTransaction");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.amount).IsRequired();
            builder.Property(t => t.description).HasMaxLength(100);
            builder.Property(t => t.transaction_date).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");
            builder.Property(t => t.create_date).IsRequired().HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.HasOne(c => c.Account)
                  .WithMany(a => a.Transactions)
                  .HasForeignKey(c => c.AccountId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
