using System;
using AutoMapper;
using BankManagement.Dtos;
using BankManagement.Dtos.Transactions;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Models.Transactions;

namespace BankManagement.Profiles;

public class TransactionProfile:Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(x => x.TransactionTypeName, a =>
                a.MapFrom(c => (((TransactionTypes)c.TransactionType.Code).GetDescription())));

        CreateMap<TransactionCreateDto, TransactionCreateModel>();
        CreateMap<TransactionUpdateDto, TransactionUpdateModel>();
        CreateMap<Transaction, TransactionEventModel>();
        CreateMap<TransactionEventModel, TransactionElasticModel>()
            .ForMember(x=>x.ElasticCreationTime,a=>
                a.MapFrom(x=>DateTime.Now));
    }
}