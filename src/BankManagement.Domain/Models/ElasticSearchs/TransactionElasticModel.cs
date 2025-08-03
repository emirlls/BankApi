using System;

namespace BankManagement.Models.ElasticSearchs;

public class TransactionElasticModel
{
    public Guid Id { get; set; }
    public Guid? TenantId { get; set; }
    public Guid TransactionTypeId { get; set; }
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public double Balance { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? ElasticCreationTime { get; set; }
}