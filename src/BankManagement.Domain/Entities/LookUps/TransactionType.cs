using System;
using System.Collections.Generic;

namespace BankManagement.Entities.LookUps;

public class TransactionType : LookupBaseEntity
{
    public virtual ICollection<Transaction> Transactions { get; set; }

    public TransactionType(Guid id, Guid? tenantId, DateTime creationTime) : base(id, tenantId, creationTime)
    {
    }
}