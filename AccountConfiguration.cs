using BankModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BankModule.Configuration
{
    public class AccountConfiguration:IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("BankModuleAccount");
            builder.HasKey(x => x.Id);

            builder.Property(a => a.account_name).IsRequired().HasMaxLength(50);
            builder.Property(a => a.account_number).IsRequired().HasMaxLength(50);
            builder.Property(a => a.iban).IsRequired().HasMaxLength(26);
            builder.Property(a => a.is_active).IsRequired();
            builder.Property(a => a.balance).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasOne(a => a.Customer)
                   .WithMany(c => c.Accounts)
                   .HasForeignKey(a => a.CustomerId);


            builder.HasMany(a => a.Cards)
                    .WithOne(c => c.Account)
                    .HasForeignKey(c => c.AccountId);

            builder.HasMany(a => a.Transactions)
                .WithOne(t => t.Account)
                .HasForeignKey(t => t.AccountId);
        }
    }
}
