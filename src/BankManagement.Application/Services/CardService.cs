using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Cards;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.ExceptionCodes;
using BankManagement.Interfaces;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class CardService:ApplicationService,ICardService
{
    private readonly ICardRepository _cardRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly CardManager _cardManager;
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;

    public CardService(ICardRepository cardRepository, IAccountRepository accountRepository, ICustomerRepository customerRepository, IStringLocalizer<BankManagementResource> stringLocalizer, CardManager cardManager)
    {
        _cardRepository = cardRepository;
        _accountRepository = accountRepository;
        _customerRepository = customerRepository;
        _stringLocalizer = stringLocalizer;
        _cardManager = cardManager;
    }

    public async Task<CardCommonDto> CreateAsync(CardCreateDto cardCreateDto, CancellationToken cancellationToken = default)
    {
        var account = await _accountRepository.FindAsync(x => x.Id.Equals(cardCreateDto.AccountId) && x.IsAvailable.Equals(true), cancellationToken: cancellationToken);

        if (account == null)
        {
            throw new UserFriendlyException(_stringLocalizer[AccountExceptionCodes.NotFound]);
        }
        
        var customer = await _customerRepository.GetAsync(x => x.Id.Equals(account.CustomerId), cancellationToken: cancellationToken);
        var cardOwner = $"{customer.Name} {customer.Surname}";
        cardCreateDto.CardOwner = cardOwner;
        var card = _cardManager.Create(account.Id, cardCreateDto.CardOwner, cardCreateDto.CardNumber, cardCreateDto.Cvv,
            cardCreateDto.CardTypeId, cardCreateDto.IsActive);

        await _cardRepository.InsertAsync(card, cancellationToken: cancellationToken);

        return ObjectMapper.Map<Card, CardCommonDto>(card);
        
        /*return new CardCommonDto()
        {
            AccountId = card.AccountId,
            CardNumber = card.CardNumber,
            CardOwner = card.CardOwner,
            CardTypeId = card.CardTypeId,
            CardTypeName = card.CardTypes.Name,
            Cvv = card.Cvv,
            IsActive = card.IsActive
        };*/
    }

    public async Task<CardCommonDto> UpdateAsync(Guid id, CardUpdateDto cardUpdateDto, CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.FindAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (card == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CardExceptionCodes.NotFound]);
        }

        _cardManager.Update(card, cardUpdateDto.CardOwner, cardUpdateDto.CardNumber, cardUpdateDto.Cvv,
            cardUpdateDto.CardTypeId, cardUpdateDto.IsActive);

        await _cardRepository.UpdateAsync(card, cancellationToken: cancellationToken);
        return ObjectMapper.Map<Card, CardCommonDto>(card);
        
        /*return new CardCommonDto()
        {
            AccountId = card.AccountId,
            CardNumber = card.CardNumber,
            CardOwner = card.CardOwner,
            CardTypeId = card.CardTypeId,
            CardTypeName = card.CardTypes.Name,
            Cvv = card.Cvv,
            IsActive = card.IsActive
        };*/
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.FindAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (card == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CardExceptionCodes.NotFound]);
        }

        await _cardRepository.DeleteAsync(card, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<CardCommonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await _cardRepository.FindAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);
        if (card == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CardExceptionCodes.NotFound]);
        }
        
        return ObjectMapper.Map<Card, CardCommonDto>(card);
        
        /*return new CardCommonDto()
        {
            AccountId = card.AccountId,
            CardNumber = card.CardNumber,
            CardOwner = card.CardOwner,
            CardTypeId = card.CardTypeId,
            CardTypeName = card.CardTypes.Name,
            Cvv = card.Cvv,
            IsActive = card.IsActive
        };*/
    }

    public async Task<List<CardCommonDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var cards = await _cardRepository.GetListAsync(cancellationToken: cancellationToken);
        return ObjectMapper.Map<List<Card>, List<CardCommonDto>>(cards);
    }
}