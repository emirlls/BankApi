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
        string cardNumber, 
        string cvv, 
        int cardTypeId,
        float cardLimit,
        bool isActive
    )
    {
        return new Card(GuidGenerator.Create())
        {
            AccountId = accountId,
            CardNumber = cardNumber,
            Cvv = cvv,
            CardTypeId = cardTypeId,
            Balance = 0,
            CardLimit = cardLimit,
            IsActive = isActive
        };
    }
    
    public Card Update(
        Card card, 
        bool isActive
    )
    {
        card.IsActive = isActive;
        return card;
    }
    
}