using AutoMapper;
using BankManagement.Dtos.Cards;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Localization;
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
        public void Process(Card source, CardCommonDto destination, ResolutionContext context)
        {
            var cardTypeId = source.CardTypeId;
            destination.CardTypeId = cardTypeId;
            destination.CardTypeName = _stringLocalizer[((int)(CardTypes)cardTypeId).ToString()];
        }
    }
}