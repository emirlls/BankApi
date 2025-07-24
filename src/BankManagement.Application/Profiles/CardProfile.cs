using AutoMapper;
using BankManagement.Dtos.Cards;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Repositories;

namespace BankManagement.Profiles;

public class CardProfile : Profile
{
    public CardProfile()
    {
        CreateMap<Card, CardCommonDto>()
            .ForMember(x => x.CardTypeName, a =>
                a.MapFrom(c => ((CardTypes)c.CardTypes.Code).GetDescription()))
            .ForMember(x => x.CardOwner, a =>
                a.Ignore())
            .AfterMap<CardMappingAction>();
    }

    public class CardMappingAction : IMappingAction<Card, CardCommonDto>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAccountRepository _accountRepository;

        public CardMappingAction(IAccountRepository accountRepository, ICustomerRepository customerRepository)
        {
            _accountRepository = accountRepository;
            _customerRepository = customerRepository;
        }

        public void Process(Card source, CardCommonDto destination, ResolutionContext context)
        {
            var account = _accountRepository.FindAsync(x => x.Id.Equals(source.AccountId)).Result;
            var customer = _customerRepository.FindAsync(x => x.Id.Equals(account!.CustomerId)).Result;
            destination.CardOwner = $"{customer!.Name} {customer.Surname}";
        }
    }
}