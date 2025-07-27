using System.ComponentModel;

namespace BankManagement.Enums;

public enum AccountTypes
{
    [Description("AccountTypes.ACC:01")]   //Depostie
    Deposite = 1,
    [Description("AccountTypes.ACC:02")]   //Checking
    Checking = 2,
}