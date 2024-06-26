using BankModule.Entities;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BankModule.DTOs
{
    public class CardDTO:EntityDto<Guid>
    {

        public string card_number { get; set; }

        public int expiration_month { get; set; }

        public int expiration_year { get; set; }

        public string ccv { get; set; }

        public bool is_active { get; set; }

        public decimal credit_limit { get; set; }

        public string card_type { get; set; }

        public string account_number { get; set; }
    }
}
