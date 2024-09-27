using System.Collections.Generic;
using System.Linq;
using BankManagement.Interfaces;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities.LookUps;

public class AccountType:CreationAuditedEntity<int>,ILookup
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<Account> Accounts { get; set; }
}