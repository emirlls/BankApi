using System;

namespace BankManagement.Models.Transactions;

public class TransactionEventModel
{
    public Guid Id { get; set; }
    public Guid? TenantId { get; set; }
    public Guid TransactionTypeId { get; set; }
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public float Balance { get; set; }
    public DateTime CreationTime { get; set; }
}