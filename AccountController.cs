using BankModule.DTOs;
using BankModule.ServiceInterfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankModule.Controllers
{
    [Area(BankModuleRemoteServiceConsts.ModuleName)]
    [RemoteService(Name = BankModuleRemoteServiceConsts.RemoteServiceName)]
    [Route("api/BankModule/CreateAccount")]
    public class AccountController : BankModuleController
    {
        private IAccountService _accountService;

        public AccountController(IAccountService accountService) { _accountService = accountService; }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] CustomerDTO customerDTO)
        {
            try {
                await _accountService.AddCustomerAccount(customerDTO);
                return Ok("Hesap başarıyla oluşturuldu.");

            }
            catch(Exception ex) {
                // Log the exception
                Log.Error(ex, "Error occurred while creating an account");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
