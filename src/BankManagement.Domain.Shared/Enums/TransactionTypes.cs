using System.ComponentModel;

namespace BankManagement.Enums;

public enum TransactionTypes
{
    [Description("TransactionTypes.TRA:01")]   //Vadeli
    AccountToAccount = 1,
    [Description("TransactionTypes.TRA:02")]   //Vadesiz
    AccountToCard = 2,
    [Description("TransactionTypes.TRA:02")]   //Vadesiz
    CardToAccount = 3,
}