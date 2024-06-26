using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BankModule.DTOs
{
    public class ActivityCardDTO:EntityDto<Guid>
    {
        public string card_number { get; set; }

        public bool is_active { get; set; }
    }
}
