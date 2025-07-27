using System;
using System.Collections.Generic;
using BankManagement.Entities.LookUps;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Entities;

public class Branch : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public Guid BranchTypeId { get; set; }
    public string? Name { get; set; }
    
    public virtual BranchType BranchType { get; set; }
    public virtual ICollection<BranchMapFeature> BranchMapFeatures { get; set; }
    
    public Branch(Guid id, Guid? tenantId, DateTime creationTime)
    {
        Id = id;
        TenantId = tenantId;
        CreationTime = creationTime;
    }
}