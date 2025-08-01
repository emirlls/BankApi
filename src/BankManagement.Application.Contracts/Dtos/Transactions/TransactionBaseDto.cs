using System;

namespace BankManagement.Dtos.Transactions;

public class TransactionBaseDto
{
    public Guid TransactionTypeId { get; set; }
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public float Balance { get; set; }
}