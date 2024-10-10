using System;

namespace BankManagement.Dtos;

public class AccountCreateDto
{
    public Guid CustomerId { get; set; }
    public string Iban { get; set; }
    public int AccountTypeId { get; set; }
    public bool IsAvailable { get; set; }
    public float Balance { get; set; }
}