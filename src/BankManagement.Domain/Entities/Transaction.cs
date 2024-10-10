using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities;

public class Transaction : FullAuditedEntity<Guid>
{
    public Guid AccountId { get; set; }
    public string SendIban { get; set; }
    public float Balance { get; set; }
    public virtual Account Account { get; set; }

    public Transaction()
    {
        
    }
    public Transaction(Guid id)
    {
        Id = id;
        
    }
}