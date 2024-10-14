using AutoMapper;
using BankManagement.Dtos;
using BankManagement.Dtos.Customers;
using BankManagement.Entities;

namespace BankManagement.Profiles;

public class CustomerProfile:Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(x => x.IdentityNumber, a =>
                a.MapFrom(c=>c.IdentityNumber))
            .ForMember(x => x.Name, a =>
                a.MapFrom(c => c.Name))
            .ForMember(x => x.Surname, a =>
                a.MapFrom(c => c.Surname))
            .ForMember(x => x.Mail, a =>
                a.MapFrom(c => c.Mail))
            .ForMember(x => x.Phone, a =>
                a.MapFrom(c => c.Phone))
            .ForMember(x => x.Birthday, a =>
                a.MapFrom(c => c.Birthday))
            .AfterMap<CustomerMappingAction>();

    }
    
    public class CustomerMappingAction:IMappingAction<Customer,CustomerDto>
    {
        public CustomerMappingAction()
        {
        }

        public void Process(Customer source, CustomerDto destination, ResolutionContext context)
        {
            
        }
    }
}