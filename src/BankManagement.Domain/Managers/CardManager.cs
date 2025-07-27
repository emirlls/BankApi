using System;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Models.Cards;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Managers;

public class CardManager : ExtendedManager<Card, ICardRepository>
{
    public CardManager(ICardRepository repository, IStringLocalizer<BankManagementResource> stringLocalizer) : base(
        repository, stringLocalizer, CardExceptionCodes.NotFound)
    {
    }

    public Card Create(
        CardCreateModel cardCreateModel
    )
    {
        return new Card(GuidGenerator.Create(), CurrentTenant.Id, DateTime.Now)
        {
            AccountId = cardCreateModel.AccountId,
            CardNumber = cardCreateModel.CardNumber,
            Cvv = cardCreateModel.Cvv,
            CardTypeId = cardCreateModel.CardTypeId,
            Balance = 0,
            CardLimit = cardCreateModel.CardLimit,
            IsActive = cardCreateModel.IsActive
        };
    }

    public Card Update(
        Card card,
        CardUpdateModel cardUpdateModel
    )
    {
        card.AccountId = cardUpdateModel.AccountId;
        card.CardNumber = cardUpdateModel.CardNumber;
        card.Cvv = cardUpdateModel.Cvv;
        card.CardTypeId = cardUpdateModel.CardTypeId;
        card.Balance = cardUpdateModel.Balance;
        card.CardLimit = cardUpdateModel.CardLimit;
        card.IsActive = cardUpdateModel.IsActive;
        return card;
    }
}