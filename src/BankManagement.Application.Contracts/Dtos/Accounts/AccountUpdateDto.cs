using System;

namespace BankManagement.Dtos.Accounts;

public class AccountUpdateDto
{
    public Guid AccountTypeId { get; set; }
    public string Iban { get; set; }
    public bool IsAvailable { get; set; }
    public float Balance { get; set; }
}