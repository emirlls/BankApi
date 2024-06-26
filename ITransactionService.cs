using BankModule.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BankModule.ServiceInterfaces
{
    public interface ITransactionService:IApplicationService
    {
        Task<string> AddTransaction(TransactionDTO transactionDTO);

    }
}
