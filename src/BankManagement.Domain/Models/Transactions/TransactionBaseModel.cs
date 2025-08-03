using System;

namespace BankManagement.Models.Transactions;

public class TransactionBaseModel
{
    public Guid TransactionTypeId { get; set; }
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public double Balance { get; set; }
}