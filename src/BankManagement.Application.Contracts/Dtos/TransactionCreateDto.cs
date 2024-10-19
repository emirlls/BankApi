using BankManagement.Dtos.Transactions;

namespace BankManagement.Dtos;

public class TransactionCreateDto
{
    public string SenderIban { get; set; }
    public string RecevierIban { get; set; }
    public float Balance { get; set; }
    public int TransactionTypeId { get; set; }
}