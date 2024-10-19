using System.Linq;
using BankManagement.Interfaces;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities.LookUps;

public class TransactionType:CreationAuditedEntity<int>,ILookup
{
    public string Name { get; set; }
    public bool IsActive { get; set; }
}