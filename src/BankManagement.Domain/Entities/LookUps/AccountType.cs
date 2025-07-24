using System;
using System.Collections.Generic;

namespace BankManagement.Entities.LookUps;

public class AccountType : LookupBaseEntity
{
    public ICollection<Account> Accounts { get; set; }

    public AccountType(Guid id, Guid? tenantId, DateTime creationTime) : base(id, tenantId, creationTime)
    {
    }
}