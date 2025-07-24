using System;
using BankManagement.Entities;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class CustomerManager : DomainService
{
    public CustomerManager()
    {
    }


    public Customer Create(
        string identityNumber,
        string name,
        string surname,
        string mail,
        string phone,
        DateTime birthday
    )
    {
        return new Customer(GuidGenerator.Create(), CurrentTenant.Id, DateTime.Now)
        {
            IdentityNumber = identityNumber,
            Name = name,
            Surname = surname,
            Mail = mail,
            Phone = phone,
            Birthday = birthday
        };
    }


    public Customer Update(
        Customer customer,
        string name,
        string surname,
        string mail,
        string phone
    )
    {
        customer.Name = name;
        customer.Surname = surname;
        customer.Mail = mail;
        customer.Phone = phone;
        return customer;
    }
}