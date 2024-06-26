using BankModule.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BankModule.ServiceInterfaces
{
    public interface ICardService:IApplicationService
    {
        Task<string> AddCardAsync(CardDTO cardDTO);

        Task<string> UpdateCardActivityAsync(string cardNumber, bool is_active);

    }
}
