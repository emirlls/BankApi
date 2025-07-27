using AutoMapper;
using BankManagement.Dtos.Customers;
using BankManagement.Entities;
using BankManagement.Models.Customers;

namespace BankManagement.Profiles;

public class CustomerProfile:Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerCreateDto>();
        CreateMap<CustomerCreateDto, CustomerCreateModel>();
        CreateMap<CustomerUpdateDto, CustomerUpdateModel>();
    }
}