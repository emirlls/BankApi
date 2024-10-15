using System;

namespace BankManagement.Dtos.Cards;

public class CardCreateDto
{
    public Guid AccountId { get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public int CardTypeId { get; set; }
    public bool IsActive { get; set; }
    public float CardLimit { get; set; }
}