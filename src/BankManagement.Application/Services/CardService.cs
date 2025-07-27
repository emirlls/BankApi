using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Dtos.Cards;
using BankManagement.Entities;
using BankManagement.Managers;
using BankManagement.Models.Cards;
using BankManagement.Repositories;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class CardService : ApplicationService, ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly CardManager _cardManager;
    private readonly AccountManager _accountManager;

    public CardService(
        ICardRepository cardRepository,
        CardManager cardManager, 
        AccountManager accountManager
    )
    {
        _cardRepository = cardRepository;
        _cardManager = cardManager;
        _accountManager = accountManager;
    }
    public async Task<bool> CreateAsync(CardCreateDto cardCreateDto,
        CancellationToken cancellationToken = default)
    {
        await _accountManager.TryGetByAsync(x =>
                x.Id.Equals(cardCreateDto.AccountId) && x.IsAvailable.Equals(true),true);
        if (cardCreateDto.CardTypeId == Guid.Parse(LookupSeederConstants.CardTypes.Bank))
        {
            cardCreateDto.CardLimit = 0;
        }
        var cardCreateModel = ObjectMapper.Map<CardCreateDto, CardCreateModel>(cardCreateDto);
        var card = _cardManager.Create(cardCreateModel);
        await _cardRepository.InsertAsync(card, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, CardUpdateDto cardUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var card = await _cardManager.TryGetByAsync(x => x.Id.Equals(id), true);

        if (card.CardTypeId == Guid.Parse(LookupSeederConstants.CardTypes.Bank))
        {
            cardUpdateDto.CardLimit = 0;
        }

        var cardUpdateModel = ObjectMapper.Map<CardUpdateDto, CardUpdateModel>(cardUpdateDto);
        _cardManager.Update(card, cardUpdateModel);

        await _cardRepository.UpdateAsync(card, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await _cardManager.TryGetByAsync(x => x.Id.Equals(id), true);
        await _cardRepository.DeleteAsync(card!, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<CardCommonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await _cardManager.TryGetByAsync(x => x.Id.Equals(id), true);
        return ObjectMapper.Map<Card, CardCommonDto>(card);
    }

    public async Task<List<CardCommonDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var cards = await _cardRepository.GetListAsync(cancellationToken: cancellationToken);
        return ObjectMapper.Map<List<Card>, List<CardCommonDto>>(cards);
    }
}