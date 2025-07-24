using AutoMapper;
using BankManagement.Dtos.Accounts;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Repositories;

namespace BankManagement.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDto>()
            .ForMember(x => x.AccountTypeCode, a =>
                a.MapFrom(c => c.AccountTypes.Code))
            .ForMember(x => x.AccountTypeName, a =>
                a.MapFrom(c => ((AccountTypes)c.AccountTypes.Code).GetDescription()))
            .ForMember(x => x.CustomerName, a =>
                a.Ignore())
            .ForMember(x => x.CustomerSurname, a =>
                a.Ignore())
            .AfterMap<AccountMappingAction>();
    }

    public class AccountMappingAction : IMappingAction<Account, AccountDto>
    {
        private readonly ICustomerRepository _customerRepository;

        public AccountMappingAction(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Process(Account source, AccountDto destination, ResolutionContext context)
        {
            var customer = _customerRepository.FindAsync(x => x.Id.Equals(source.CustomerId)).Result;
            destination.CustomerName = customer!.Name;
            destination.CustomerSurname = customer.Surname;
        }
    }
}