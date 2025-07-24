using System.ComponentModel;

namespace BankManagement.Enums;

public enum TransactionTypes
{
    [Description("TransactionTypes.TRA:01")]   //Hesaptan hesaba
    AccountToAccount = 1,
    [Description("TransactionTypes.TRA:02")]   //Hesaptan karta
    AccountToCard = 2,
    [Description("TransactionTypes.TRA:03")]   //Karttan hesaba
    CardToAccount = 3,
    [Description("TransactionTypes.TRA:04")]   //Karttan karta
    CardToCard = 4,
}