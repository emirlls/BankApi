using System;

namespace BankManagement.Dtos.Cards;

public class CardBaseDto
{
    public Guid AccountId { get; set; }
    public Guid CardTypeId { get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public bool IsActive { get; set; }
    public float CardLimit { get; set; }
}