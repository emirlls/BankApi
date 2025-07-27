using System.ComponentModel;

namespace BankManagement.Enums;

public enum CardTypes
{
    [Description("CardTypes.CAR:01")]   //Bank Card
    Bank = 1,
    [Description("CardTypes.CAR:02")]   //Credit Card
    Credit = 2,
}