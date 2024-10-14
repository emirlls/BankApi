namespace BankManagement.Dtos;

public class AccountUpdateDto
{
    public string Iban { get; set; }
    public int AccountTypeId { get; set; }
    public bool IsAvailable { get; set; }
    public float Balance { get; set; }
}