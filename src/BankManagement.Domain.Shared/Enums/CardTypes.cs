using System.ComponentModel;

namespace BankManagement.Enums;

public enum CardTypes
{
    [Description("CardTypes.CAR:01")]   //Banka kartı
    Bank = 1,
    [Description("CardTypes.CAR:02")]   //Kredi kartı
    Credit = 2,
}