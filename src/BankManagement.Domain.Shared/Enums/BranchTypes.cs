using System.ComponentModel;

namespace BankManagement.Enums;

public enum BranchTypes
{
    [Description("BranchTypes:01")]   //Branch
    Branch = 1,
    [Description("BranchTypes:02")]   //Atm
    Atm = 2,
}