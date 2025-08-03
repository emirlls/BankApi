using System;

namespace BankManagement.Dtos.Transactions;

public class TransactionDto
{
    public Guid TransactionTypeId { get; set; }
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public double Balance { get; set; }
    public string TransactionTypeName { get; set; }
    
}