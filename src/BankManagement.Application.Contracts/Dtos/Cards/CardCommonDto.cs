using System;

namespace BankManagement.Dtos.Cards;

public class CardCommonDto:CardCreateDto
{
    public string CardTypeName { get; set; }
    
    public string CardOwner { get; set; }
    
}