using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text;
using System.Transactions;
using Volo.Abp.Domain.Entities;

namespace BankModule.Entities
{
    public class Account:Entity<Guid>
    {
        public string account_name { get; set; }

        public string account_number { get; set; }

        public string iban { get; set; }

        public bool is_active { get; set; }

        public decimal balance { get; set; }

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }

        //public ICollection<Cards> Cards { get; set; }
        //public ICollection<Transaction> Transactions { get; set; }

        public ICollection<Cards> Cards { get; set; } = new List<Cards>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
