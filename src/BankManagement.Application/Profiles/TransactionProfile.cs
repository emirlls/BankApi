using AutoMapper;
using BankManagement.Dtos.Transactions;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;

namespace BankManagement.Profiles;

public class TransactionProfile:Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(x => x.TransactionTypeName, a =>
                a.MapFrom(c => (((TransactionTypes)c.TransactionType.Code).GetDescription())));
    }
}