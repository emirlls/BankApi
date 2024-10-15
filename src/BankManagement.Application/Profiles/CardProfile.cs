using AutoMapper;
using BankManagement.Dtos.Cards;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Localization;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Profiles;

public class CardProfile:Profile
{
    public CardProfile()
    {
        CreateMap<Card, CardCommonDto>()
            .ForMember(x => x.AccountId, a =>
                a.MapFrom(c => c.AccountId))
            .ForMember(x => x.CardNumber, a =>
                a.MapFrom(c => c.CardNumber))
            .ForMember(x => x.Cvv, a =>
                a.MapFrom(c => c.Cvv))
            .ForMember(x => x.IsActive, a =>
                a.MapFrom(c => c.IsActive))
            .ForMember(x => x.CardLimit, a =>
                a.MapFrom(c => c.CardLimit))
            .ForMember(x => x.CardTypeId, a =>
                a.Ignore())
            .ForMember(x => x.CardTypeName, a =>
                a.Ignore())
            .ForMember(x => x.CardOwner, a =>
                a.Ignore())
            .AfterMap<CardMappingAction>();
    }
    
    public class CardMappingAction:IMappingAction<Card,CardCommonDto>
    {
        private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public CardMappingAction(IAccountRepository accountRepository, ICustomerRepository customerRepository, IStringLocalizer<BankManagementResource> stringLocalizer)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
            _stringLocalizer = stringLocalizer;
        }

        public void Process(Card source, CardCommonDto destination, ResolutionContext context)
        {
            var cardTypeId = source.CardTypeId;
            var account = _accountRepository.FindAsync(x => x.Id.Equals(source.AccountId)).Result;
            var customer = _customerRepository.FindAsync(x => x.Id.Equals(account!.CustomerId)).Result;
            destination.CardTypeId = cardTypeId;
            destination.CardTypeName = _stringLocalizer[((CardTypes)cardTypeId).GetDescription()];
            destination.CardOwner = $"{customer!.Name} {customer.Surname}";

        }
    }
}