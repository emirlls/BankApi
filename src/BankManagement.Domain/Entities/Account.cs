using System;
using System.Collections.Generic;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities;

public class Account:FullAuditedEntity<Guid>
{
    public Guid CustomerId { get; set; }
    public string Iban { get; set; }
    public int AccountTypeId { get; set; }
    public bool IsAvailable { get; set; }
    public float Balance { get; set; }
    
    public virtual Customer Customer { get; set; }
    public virtual AccountType AccountTypes { get; set; }
    public ICollection<Card> Cards { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    
    public Account()
    {
        
    }
    public Account(Guid id)
    {
        Id = id;
        
    }
}