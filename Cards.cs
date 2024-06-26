using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace BankModule.Entities
{
    public class Cards:Entity<Guid>
    {


        public string card_number { get; set; }

        public int expiration_month { get; set; }

        public int expiration_year { get; set; }


        public string ccv { get; set; }

        public bool is_active { get; set; }

        public decimal credit_limit { get; set; }

        public string card_type { get; set; }

        public Guid AccountId { get; set; }

        public Account Account { get; set; }
    }
}
