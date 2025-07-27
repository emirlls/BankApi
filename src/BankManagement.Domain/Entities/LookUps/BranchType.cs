using System;
using System.Collections.Generic;

namespace BankManagement.Entities.LookUps;

public class BranchType : LookupBaseEntity
{
    public ICollection<Branch> Branches { get; set; }

    public BranchType(Guid id, Guid? tenantId, DateTime creationTime) : base(id, tenantId, creationTime)
    {
    }
}