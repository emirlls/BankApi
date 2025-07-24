using System;
using BankManagement.Entities;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class CardManager:DomainService
{
    public CardManager()
    {
    }

    public Card Create(
        Guid accountId, 
        Guid cardTypeId,
        string cardNumber, 
        string cvv, 
        float cardLimit,
        bool isActive
    )
    {
        return new Card(GuidGenerator.Create(),CurrentTenant.Id,DateTime.Now)
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