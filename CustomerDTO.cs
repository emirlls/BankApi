using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace BankModule.DTOs
{
    public class CustomerDTO:EntityDto<Guid>
    {
        public string full_name { get; set; }
        public string identity_number { get; set; }
        public string birth_place { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal risk_limit { get; set; }

        public string account_name { get; set; }
        public string account_number { get; set; }
        public string iban { get; set; }
        public bool is_active { get; set; }

    }
}
