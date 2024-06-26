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
    [Route("api/BankModule/ActivityCard")]

    public class ActivityCardController:BankModuleController
    {
        private readonly ICardService _cardService;
        public ActivityCardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> ActivityCard([FromBody] ActivityCardDTO activityCardDTO)
        {
            var result = await _cardService.UpdateCardActivityAsync(activityCardDTO.card_number,activityCardDTO.is_active);
            return Ok(result);
        }
    }
}
