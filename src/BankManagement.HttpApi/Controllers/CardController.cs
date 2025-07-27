using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Attributes;
using BankManagement.Constants;
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
    /// <summary>
    /// Used to get list of cards
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [CacheManagement<CardCommonDto>(CacheModelConstants.CardCacheModel)]
    public async Task<List<CardCommonDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _cardService.GetListAsync(cancellationToken);
    }
    
    /// <summary>
    /// Used to get the card with id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<CardCommonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _cardService.GetByIdAsync(id, cancellationToken);
    }

    /// <summary>
    /// Used to create api
    /// </summary>
    /// <param name="cardCreateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [CacheClear<CardCommonDto>(CacheModelConstants.CardCacheModel)]
    public async Task<bool> CreateAsync(CardCreateDto cardCreateDto,
        CancellationToken cancellationToken = default)
    {
        return await _cardService.CreateAsync(cardCreateDto, cancellationToken);
    }

    /// <summary>
    /// Used to update card
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cardUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    [CacheClear<CardCommonDto>(CacheModelConstants.CardCacheModel)]
    public async Task<bool> UpdateAsync(Guid id, CardUpdateDto cardUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _cardService.UpdateAsync(id, cardUpdateDto, cancellationToken);
    }

    /// <summary>
    /// Used to delete card
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    [CacheClear<CardCommonDto>(CacheModelConstants.CardCacheModel)]
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _cardService.DeleteAsync(id, cancellationToken);
    }
}