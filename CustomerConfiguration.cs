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
    public class CustomerConfiguration:IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("BankModuleCustomer");
            builder.HasKey(x => x.Id); // ABP'nin GUID tipi ID'si

            builder.Property(c => c.full_name).IsRequired().HasMaxLength(100);
            builder.Property(c => c.identity_number).IsRequired().HasMaxLength(100);
            builder.Property(c => c.birth_place).IsRequired().HasMaxLength(100);
            builder.Property(c => c.birth_date).IsRequired();
            builder.Property(c => c.risk_limit).IsRequired().HasColumnType("decimal(18,2)");

            builder.HasMany(c => c.Accounts)
                   .WithOne(a => a.Customer)
                   .HasForeignKey(a => a.CustomerId);

        }
    }
}
