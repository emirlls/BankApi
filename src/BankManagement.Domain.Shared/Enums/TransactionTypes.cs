using System.ComponentModel;

namespace BankManagement.Enums;

public enum TransactionTypes
{
    [Description("TransactionTypes:01")]   //To Account
    ToAccount = 1,
    [Description("TransactionTypes:02")]   //To Card
    ToCard = 2,
}