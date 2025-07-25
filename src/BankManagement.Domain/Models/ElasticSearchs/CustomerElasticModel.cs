using System;

namespace BankManagement.Models.ElasticSearchs;

public class CustomerElasticModel
{
    public Guid Id { get; }
    public Guid? TenantId { get; }
    public string IdentityNumber { get; set; }
    public string Name{ get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? ElasticCreationTime { get; set; }
}