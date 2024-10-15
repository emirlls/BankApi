using System.ComponentModel;

namespace BankManagement.Enums;

public enum AccountTypes
{
    [Description("AccountTypes.ACC:01")]   //Vadeli
    Deposite = 1,
    [Description("AccountTypes.ACC:02")]   //Vadesiz
    Checking = 2,
}