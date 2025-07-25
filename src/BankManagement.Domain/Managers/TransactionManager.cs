using System;
using BankManagement.Entities;
using BankManagement.Localization;
using BankManagement.Models.Transactions;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Managers;

public class TransactionManager : ExtendedManager<Transaction, ITransactionRepository>
{
    public TransactionManager(ITransactionRepository repository,
        IStringLocalizer<BankManagementResource> stringLocalizer) : base(repository, stringLocalizer)
    {
    }
    public Transaction Create(TransactionCreateModel transactionCreateModel)
    {
        return new Transaction(GuidGenerator.Create(), CurrentTenant.Id, DateTime.Now)
        {
            TransactionTypeId = transactionCreateModel.TransactionTypeId,
            SenderIban = transactionCreateModel.SenderIban,
            ReceiverIban = transactionCreateModel.RecevierIban,
            Balance = transactionCreateModel.Balance
        };
    }
    public Transaction Update(Transaction transaction, TransactionUpdateModel transactionUpdateModel)
    {
        transaction.TransactionTypeId = transactionUpdateModel.TransactionTypeId;
        transaction.SenderIban = transactionUpdateModel.SenderIban;
        transaction.ReceiverIban = transactionUpdateModel.RecevierIban;
        transaction.Balance = transactionUpdateModel.Balance;
        return transaction;
    }
}