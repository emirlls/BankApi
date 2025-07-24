using AutoMapper;
using BankManagement.Dtos.Customers;
using BankManagement.Entities;

namespace BankManagement.Profiles;

public class CustomerProfile:Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>();

    }
}