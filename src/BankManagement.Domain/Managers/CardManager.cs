using System;
using BankManagement.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class CardManager:DomainService
{
    public CardManager()
    {
    }

    public Card Create(
        Guid accountId, 
        string cardOwner, 
        string cardNumber, 
        string cvv, 
        int cardTypeId,
        bool isActive
    )
    {
        return new Card(GuidGenerator.Create())
        {
            AccountId = accountId,
            CardOwner = cardOwner,
            CardNumber = cardNumber,
            Cvv = cvv,
            CardTypeId = cardTypeId,
            IsActive = isActive
        };
    }
    
    public Card Update(
        Card card, 
        string cardOwner, 
        string cardNumber, 
        string cvv, 
        int cardTypeId,
        bool isActive
    )
    {
        card.CardOwner = cardOwner;
        card.CardNumber = cardNumber;
        card.Cvv = cvv;
        card.CardTypeId = cardTypeId;
        card.IsActive = isActive;

        return card;
    }
    
}