using System;
using AutoMapper;
using BankManagement.Dtos.ElasticLogs;
using BankManagement.Entities;
using BankManagement.Models.ElasticSearchs;

namespace BankManagement.Profiles;

public class ElasticProfile : Profile
{
    public ElasticProfile()
    {
        CreateMap<Transaction, TransactionElasticModel>()
            .ForMember(x => x.ElasticCreationTime, a =>
                a.MapFrom(x => DateTime.Now));
        CreateMap<Customer, CustomerElasticModel>()
            .ForMember(x => x.ElasticCreationTime, a =>
                a.MapFrom(x => DateTime.Now));
        CreateMap<Account, AccountElasticModel>()
            .ForMember(x => x.ElasticCreationTime, a =>
                a.MapFrom(x => DateTime.Now));
        CreateMap<Card, CardElasticModel>()
            .ForMember(x => x.ElasticCreationTime, a =>
                a.MapFrom(x => DateTime.Now));

        CreateMap<TransactionElasticModel, ElasticLogDto>()
            .ForMember(x => x.ModelName, a =>
                a.MapFrom(x => nameof(TransactionElasticModel)));

        CreateMap<CustomerElasticModel, ElasticLogDto>()
            .ForMember(x => x.ModelName, a =>
                a.MapFrom(x => nameof(CustomerElasticModel)));

        CreateMap<AccountElasticModel, ElasticLogDto>()
            .ForMember(x => x.ModelName, a =>
                a.MapFrom(x => nameof(AccountElasticModel)));

        CreateMap<CardElasticModel, ElasticLogDto>()
            .ForMember(x => x.ModelName, a =>
                a.MapFrom(x => nameof(CardElasticModel)));
    }
}