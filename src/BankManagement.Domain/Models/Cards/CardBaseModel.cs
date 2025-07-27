using System;

namespace BankManagement.Models.Cards;

public class CardBaseModel
{
    public Guid AccountId { get; set; }
    public Guid CardTypeId { get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public bool IsActive { get; set; }
    public float CardLimit { get; set; }
}