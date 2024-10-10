using System.ComponentModel;

namespace BankManagement.Enums;

public enum AccountTypes
{
    [Description("STT:01")]   //Vadeli
    Deposite = 1,
    [Description("STT:02")]   //Vadesiz
    Checking = 2,
}