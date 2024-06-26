using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace BankModule.Entities
{
    public class Customer:Entity<Guid>
    {

        public string full_name { get; set; }

        public string identity_number { get; set; }

        public string birth_place { get; set; }

        public DateTime birth_date { get; set; }

        public decimal risk_limit { get; set; }

        public ICollection<Account> Accounts { get; set; }=new List<Account>();

    }
}
