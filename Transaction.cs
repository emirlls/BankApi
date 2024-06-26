using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace BankModule.Entities
{
    public class Transaction:Entity<Guid>
    {

        public decimal amount { get; set; }

        public string description { get; set; }

        public string transaction_type { get; set; }

        public DateTime transaction_date { get; set; }

        public DateTime create_date { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}
