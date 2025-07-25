using System;

namespace BankManagement.Models.ElasticSearchs;

public class CardElasticModel
{
    public Guid Id { get; }
    public Guid? TenantId { get; }
    public Guid AccountId { get; set; } 
    public string CardNumber { get; set; }
    public string Cvv { get; set; }
    public float? CardLimit { get; set; }
    public float Balance { get; set; }
    public bool IsActive{ get; set; }
    public Guid CardTypeId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? ElasticCreationTime { get; set; }
}