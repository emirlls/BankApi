using System;

namespace BankManagement.Dtos.Accounts;

public class AccountDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string CustomerSurname { get; set; }
    public string Iban { get; set; }
    public int AccountTypeCode { get; set; }
    public string AccountTypeName { get; set; }
    public bool IsAvailable { get; set; }
    public double Balance { get; set; }
}