using System;

namespace BankManagement.Dtos;

public class TransactionCreateDto
{
    public Guid TransactionTypeId { get; set; }
    public string SenderIban { get; set; }
    public string RecevierIban { get; set; }
    public float Balance { get; set; }
}