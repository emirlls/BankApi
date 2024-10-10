namespace BankManagement.Dtos;

public class AccountDto
{
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string Iban { get; set; }
    public int AccountTypeId { get; set; }
    public string AccountType { get; set; }
    public bool IsAvailable { get; set; }
    public float Balance { get; set; }
}