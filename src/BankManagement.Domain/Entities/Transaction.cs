using System;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Entities;

public class Transaction : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public double Balance { get; set; }
    public Guid TransactionTypeId { get; set; }
    public virtual TransactionType TransactionType { get; set; }
    public Transaction()
    {
        
    }
    public Transaction(Guid id,Guid? tenantId, DateTime creationTime)
    {
        Id = id;
        TenantId = tenantId;
        CreationTime = creationTime;
    }

}