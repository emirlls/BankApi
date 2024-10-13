using AutoMapper;
using BankManagement.Dtos;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity; 

namespace BankManagement.Profiles;

public class AccountProfile:Profile
{
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;
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
                a.MapFrom(c => c.AccountTypeId))
            .ForMember(x => x.AccountType, a =>
                a.MapFrom(c => (AccountTypes)c.AccountTypeId))
            .ForMember(x=>x.CustomerName,a=>
                a.Ignore())
            .ForMember(x=>x.CustomerSurname,a=>
                a.Ignore())
            .AfterMap<AccountMappingAction>();
    }
    
    public class AccountMappingAction:IMappingAction<Account,AccountDto>
    {
        private readonly IIdentityUserRepository _ıdentityUserRepository;

        public AccountMappingAction(IIdentityUserRepository ıdentityUserRepository)
        {
            _ıdentityUserRepository = ıdentityUserRepository;
        }

        public void Process(Account source, AccountDto destination, ResolutionContext context)
        {
            var user = _ıdentityUserRepository.GetAsync(source.CustomerId);
            destination.CustomerName = user.Result.Name;
            destination.CustomerSurname = user.Result.Surname;
        }
    }
}