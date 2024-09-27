using System.Collections.Generic;
using BankManagement.Interfaces;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities.LookUps;

public class CardType:CreationAuditedEntity<int>,ILookup
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
    
    public ICollection<Card> Cards { get; set; }
}