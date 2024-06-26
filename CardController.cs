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
    [Route("api/BankModule/CreateCard")]
    public class CardController:BankModuleController
    {
        private readonly ICardService _cardService;
        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody]CardDTO cardDTO)
        {
             var result=await _cardService.AddCardAsync(cardDTO);
            return Ok(result);
            //return Ok("Kart başarıyla oluşturuldu.");
        }
    }
}
