using AutoMapper;
using BankManagement.Dtos;
using BankManagement.Dtos.Accounts;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Localization;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity; 

namespace BankManagement.Profiles;

public class AccountProfile:Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDto>()
            .ForMember(x => x.Iban, a =>
                a.MapFrom(c => c.Iban))
            .ForMember(x => x.Balance, a =>
                a.MapFrom(c => c.Balance))
            .ForMember(x => x.IsAvailable, a =>
                a.MapFrom(c => c.IsAvailable))
            .ForMember(x => x.AccountTypeId, a =>
                a.Ignore())
            .ForMember(x => x.AccountTypeName, a =>
                a.Ignore())
            .ForMember(x=>x.CustomerName,a=>
                a.Ignore())
            .ForMember(x=>x.CustomerSurname,a=>
                a.Ignore())
            
            .AfterMap<AccountMappingAction>();
    }
    
    public class AccountMappingAction:IMappingAction<Account,AccountDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;

        public AccountMappingAction(ICustomerRepository customerRepository, IStringLocalizer<BankManagementResource> stringLocalizer)
        {
            _customerRepository = customerRepository;
            _stringLocalizer = stringLocalizer;
        }

        public void Process(Account source, AccountDto destination, ResolutionContext context)
        {
            var customer = _customerRepository.FindAsync(x => x.Id.Equals(source.CustomerId)).Result;
            destination.CustomerName = customer!.Name;
            destination.CustomerSurname = customer.Surname;
            var accountTypeId = source.AccountTypeId;
            destination.AccountTypeId = accountTypeId;
            destination.AccountTypeName = _stringLocalizer[((AccountTypes)accountTypeId).GetDescription()];

        }
    }
}