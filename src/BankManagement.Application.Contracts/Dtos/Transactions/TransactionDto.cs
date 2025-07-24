namespace BankManagement.Dtos.Transactions;

public class TransactionDto
{
    public string SenderIban { get; set; }
    public string RecevierIban { get; set; }
    public float Balance { get; set; }
    public int TransactionTypeId { get; set; }
    
    public string TransactionTypeName { get; set; }
    
}