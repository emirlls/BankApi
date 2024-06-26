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
    [Route("api/BankModule/ActivityAccount")]

    public class ActivityAccountController:BankModuleController
    {
        private readonly IAccountService _accountService;
        public ActivityAccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<IActionResult> ActivityAccount([FromBody]ActivityAccountDTO activityAccountDTO)
        {
            var result = await _accountService.UpdateCustomerAccount(activityAccountDTO.account_number,activityAccountDTO.is_active);
            return Ok(result);
        }
    }
}
