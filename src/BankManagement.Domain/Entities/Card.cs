using System;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Entities;

public class Card:FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid AccountId { get; set; } 
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public float? CardLimit { get; set; }
    public float Balance { get; set; }
    public bool IsActive{ get; set; }
    public Guid CardTypeId { get; set; }
    public virtual Account Accounts { get; set; }
    public virtual CardType CardTypes { get; set; }

    public Card()
    {
        
    }
    public Card(Guid id,Guid? tenantId, DateTime creationTime)
    {
        Id = id;
        TenantId = tenantId;
        CreationTime = creationTime;
    }

}