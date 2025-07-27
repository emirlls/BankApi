using System;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Models.Customers;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Managers;

public class CustomerManager : ExtendedManager<Customer, ICustomerRepository>
{
    public CustomerManager(ICustomerRepository repository, IStringLocalizer<BankManagementResource> stringLocalizer) :
        base(repository, stringLocalizer, CustomerExceptionCodes.NotFound)
    {
    }

    public Customer Create(
        CustomerCreateModel customerCreateModel
    )
    {
        return new Customer(GuidGenerator.Create(), CurrentTenant.Id, DateTime.Now)
        {
            IdentityNumber = customerCreateModel.IdentityNumber,
            Name = customerCreateModel.Name,
            Surname = customerCreateModel.Surname,
            Mail = customerCreateModel.Mail,
            Phone = customerCreateModel.Phone,
            Birthday = customerCreateModel.Birthday
        };
    }


    public Customer Update(
        Customer customer,
        CustomerUpdateModel customerUpdateModel
    )
    {
        customer.IdentityNumber = customerUpdateModel.IdentityNumber;
        customer.Name = customerUpdateModel.Name;
        customer.Surname = customerUpdateModel.Surname;
        customer.Mail = customerUpdateModel.Mail;
        customer.Phone = customer.Phone;
        customer.Birthday = customer.Birthday;
        return customer;
    }
}