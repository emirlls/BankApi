using System;

namespace BankManagement.Dtos.Branches;

public class BranchBaseDto
{
    public Guid BranchTypeId { get; set; }
    public string? Name { get; set; }
    public string? GeoJson { get; set; }
}