using AutoMapper;
using BankManagement.Dtos.Accounts;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Models.Accounts;

namespace BankManagement.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDto>()
            .ForMember(x => x.CustomerId, a =>
                a.MapFrom(x => x.Customer.Id))
            .ForMember(x => x.AccountTypeCode, a =>
                a.MapFrom(c => c.AccountTypes.Code))
            .ForMember(x => x.AccountTypeName, a =>
                a.MapFrom(c => ((AccountTypes)c.AccountTypes.Code).GetDescription()))
            .ForMember(x => x.CustomerName, a =>
                a.MapFrom(x => x.Customer.Name))
            .ForMember(x => x.CustomerSurname, a =>
                a.MapFrom(x => x.Customer.Surname));

        CreateMap<AccountCreateDto, AccountCreateModel>();
        CreateMap<AccountUpdateDto, AccountUpdateModel>();
    }
}