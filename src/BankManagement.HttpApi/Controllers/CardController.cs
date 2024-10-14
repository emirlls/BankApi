using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Cards;
using BankManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BankManagement.Controllers;

//[Authorize]
[ApiController]
[Route("api/bank-management/cards")]
public class CardController:AbpControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("{id}")]
    public async Task<CardCommonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _cardService.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public async Task<CardCommonDto> CreateAsync(CardCreateDto cardCreateDto,
        CancellationToken cancellationToken = default)
    {
        return await _cardService.CreateAsync(cardCreateDto, cancellationToken);
    }

    [HttpPut("{id}")]
    public async Task<CardCommonDto> UpdateAsync(Guid id, CardUpdateDto cardUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _cardService.UpdateAsync(id, cardUpdateDto, cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _cardService.DeleteAsync(id, cancellationToken);
    }

    [HttpGet]
    public async Task<List<CardCommonDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _cardService.GetListAsync(cancellationToken);
    }
}