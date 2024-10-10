using System;
using BankManagement.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class CustomerManager:DomainService
{
    private readonly IRepository<Customer, Guid> _customerRepository;

    public CustomerManager(IRepository<Customer, Guid> customerRepository)
    {
        _customerRepository = customerRepository;
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
        return new Customer(GuidGenerator.Create())
        {
            IdentityNumber = identityNumber,
            Name = name,
            Surname = surname,
            Mail = mail,
            Phone = phone,
            Birthday = birthday
        };
    }
}