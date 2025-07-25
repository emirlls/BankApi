using System;

namespace BankManagement.Dtos.ElasticLogs;

public class ElasticLogDto
{
    public Guid Id { get; set; }
    public string ModelName { get; set; }
    public DateTime? CreationTime { get; set; }
    public DateTime? ElasticCreationTime { get; set; }
}