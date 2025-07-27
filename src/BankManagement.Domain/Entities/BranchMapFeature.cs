using System;
using NetTopologySuite.Geometries;
using Volo.Abp.Domain.Entities.Auditing;

namespace BankManagement.Entities;

public class BranchMapFeature : FullAuditedEntity<Guid>
{
    public Guid BranchId { get; set; }
    public Geometry? Geom { get; set; }
    
    public virtual Branch? Branch { get; set; }

    public BranchMapFeature(Guid id, DateTime creationTime)
    {
        Id = id;
        CreationTime = creationTime;
    }
}