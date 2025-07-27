using System;

namespace BankManagement.Dtos.Branches;

public class BranchDto : BranchBaseDto
{
    public Guid Id { get; set; }
    public string BranchTypeName { get; set; }
}