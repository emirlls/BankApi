using BankModule.DTOs;
using BankModule.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BankModule.ServiceInterfaces
{
    public interface IAccountService:IApplicationService
    {
        Task<Account> AddCustomerAccount(CustomerDTO customerDTO);

        Task<string> UpdateCustomerAccount(string account_Number, bool isActive);

    }
}
