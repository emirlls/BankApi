using System;
using System.Collections.Generic;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities;

public class Card:FullAuditedEntity<Guid>
{
    public Guid AccountId { get; set; } 
    public string CardOwner { get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public int CardTypeId { get; set; }
    public bool IsActive{ get; set; }
    
    public virtual Account Accounts { get; set; }
    public virtual CardType CardTypes { get; set; }

    public Card()
    {
        
    }
    public Card(Guid id)
    {
        Id = id;
        
    }
}