using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Entities;

public class Customer:FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; }
    public string IdentityNumber { get; set; }
    public string Name{ get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }

    public ICollection<Account> Accounts { get; set; }
    public Customer()
    {
        
    }
    public Customer(Guid id,Guid? tenantId, DateTime creationTime)
    {
        Id = id;
        TenantId = tenantId;
        CreationTime = creationTime;
    }
}