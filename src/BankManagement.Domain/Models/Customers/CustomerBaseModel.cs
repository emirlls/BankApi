using System;

namespace BankManagement.Models.Customers;

public class CustomerBaseModel
{
    public string IdentityNumber { get; set; }
    public string Name{ get; set; }
    public string Surname { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public DateTime Birthday { get; set; }
}