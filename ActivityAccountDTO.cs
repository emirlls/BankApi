using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BankModule.DTOs
{
    public class ActivityAccountDTO:EntityDto<Guid>
    {
        public string account_number { get; set; }
        public bool is_active { get; set; }
    }
}
