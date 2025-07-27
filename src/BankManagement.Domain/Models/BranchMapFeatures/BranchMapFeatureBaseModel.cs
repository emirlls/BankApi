using System;

namespace BankManagement.Models.BranchMapFeatures;

public class BranchMapFeatureBaseModel
{
    public Guid BranchId { get; set; }
    public string GeoJson { get; set; }
}