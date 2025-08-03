using System;

namespace BankManagement.Models.ElasticSearchs;

public class AccountElasticModel
{
    public Guid Id { get; }
    public Guid? TenantId { get; }
    public Guid CustomerId { get; set; }
    public string Iban { get; set; }
    public bool IsAvailable { get; set; }
    public double Balance { get; set; }
    public Guid AccountTypeId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? ElasticCreationTime { get; set; }
}