using System;

namespace BankManagement.Models.Accounts;

public class AccountBaseModel
{
    public Guid CustomerId { get; set; }
    public Guid AccountTypeId { get; set; }
    public string Iban { get; set; }
    public bool IsAvailable { get; set; }
    public float Balance { get; set; }
}