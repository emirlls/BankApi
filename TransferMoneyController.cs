using BankModule.DTOs;
using BankModule.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace BankModule.Controllers
{
    [Area(BankModuleRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = BankModuleRemoteServiceConsts.RemoteServiceName)]
    [Route("api/BankModule/TransferMoney")]

    public class TransferMoneyController:BankModuleController
    {
        private readonly ITransactionService _transactionService;
        public TransferMoneyController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public async Task<IActionResult> TransferMoney([FromBody] TransactionDTO transactionDTO)
        {
            var result =await _transactionService.AddTransaction(transactionDTO);
            return Ok(result);
        }
    }
}
