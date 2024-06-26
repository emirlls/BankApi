using BankModule.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankModule.Configuration
{
    public class CardConfiguration:IEntityTypeConfiguration<Cards>
    {
        public void Configure(EntityTypeBuilder<Cards> builder)
        {
            builder.ToTable("BankModuleCards");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.card_number).IsRequired().HasMaxLength(16);
            builder.Property(c => c.card_type).IsRequired().HasMaxLength(20);
            builder.Property(c => c.expiration_month).IsRequired().HasMaxLength(2);
            builder.Property(c => c.expiration_year).IsRequired().HasMaxLength(4);
            builder.Property(c => c.ccv).IsRequired().HasMaxLength(3);
            builder.Property(c => c.is_active).IsRequired();


            builder.HasOne(c => c.Account)
                   .WithMany(a => a.Cards)
                   .HasForeignKey(c => c.AccountId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
