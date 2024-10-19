using System;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities;

public class Transaction : FullAuditedEntity<Guid>
{
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public float Balance { get; set; }
    public int TransactionTypeId { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    public Transaction()
    {
        
    }
    public Transaction(Guid id)
    {
        Id = id;
        
    }
}