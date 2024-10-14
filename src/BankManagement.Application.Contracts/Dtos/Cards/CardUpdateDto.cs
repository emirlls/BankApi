namespace BankManagement.Dtos.Cards;

public class CardUpdateDto
{
    public string CardOwner { get; set; }
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public int CardTypeId { get; set; }
    public bool IsActive { get; set; }
}