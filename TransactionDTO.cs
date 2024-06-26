using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace BankModule.DTOs
{
    public class TransactionDTO:EntityDto<Guid>
    {

        public string RecipientCardNumber { get; set; }
        public decimal amount { get; set; }
        public string description { get; set; }
        public string senderIban { get; set; }
    }
}
