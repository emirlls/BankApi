using System;
using System.Collections.Generic;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Entities;

public class Account:FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid CustomerId { get; set; }
    public string Iban { get; set; }
    public bool IsAvailable { get; set; }
    public double Balance { get; set; }
    public Guid AccountTypeId { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual AccountType AccountTypes { get; set; }
    public ICollection<Card> Cards { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    
    public Account()
    {
        
    }
    public Account(Guid id,Guid? tenantId, DateTime creationTime)
    {
        Id = id;
        TenantId = tenantId;
        CreationTime = creationTime;
    }

}