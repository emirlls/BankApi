using System;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Entities.LookUps;

public abstract class LookupBaseEntity : CreationAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public int Code { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    
    public LookupBaseEntity(Guid id, Guid? tenantId, DateTime creationTime)
    {
        Id = id;
        TenantId = tenantId;
        CreationTime = creationTime;
    }
}