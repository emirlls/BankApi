using AutoMapper;
using BankManagement.Dtos.Accounts;
using BankManagement.Dtos.Transactions;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Localization;
using Microsoft.Extensions.Localization;

namespace BankManagement.Profiles;

public class TransactionProfile:Profile
{
    public TransactionProfile()
    {
        CreateMap<Transaction, TransactionDto>()
            .ForMember(x => x.SenderIban, a =>
                a.MapFrom(c => c.SenderIban))
            .ForMember(x => x.RecevierIban, a =>
                a.MapFrom(c => c.ReceiverIban))
            .ForMember(x => x.Balance, a =>
                a.MapFrom(c => c.Balance))
            .ForMember(x => x.TransactionTypeId, a =>
                a.Ignore())
            .ForMember(x => x.TransactionTypeName, a =>
                a.Ignore())
            .AfterMap<TransactionMappingAction>();
    }

    public class TransactionMappingAction : IMappingAction<Transaction, TransactionDto>
    {
        private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;

        public TransactionMappingAction(IStringLocalizer<BankManagementResource> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public void Process(Transaction source, TransactionDto destination, ResolutionContext context)
        {
            var transactionTypeId = source.TransactionTypeId;
            destination.TransactionTypeId = transactionTypeId;
            destination.TransactionTypeName = _stringLocalizer[((TransactionTypes)transactionTypeId).GetDescription()];

        }
    }
}