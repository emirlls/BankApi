using System;

namespace BankManagement.Models.Branches;

public class BranchBaseModel
{
    public Guid BranchTypeId { get; set; }
    public string? Name { get; set; }
}