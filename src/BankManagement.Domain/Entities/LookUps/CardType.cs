using System;
using System.Collections.Generic;

namespace BankManagement.Entities.LookUps;

public class CardType : LookupBaseEntity
{
    public ICollection<Card> Cards { get; set; }

    public CardType(Guid id, Guid? tenantId, DateTime creationTime) : base(id, tenantId, creationTime)
    {
    }
}