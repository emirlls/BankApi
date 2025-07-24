using System;
using BankManagement.Entities;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class TransactionManager : DomainService
{
    public TransactionManager()
    {
    }

    public Transaction Create(Guid transactionTypeId, string senderIban, string receiverIban, float balance)
    {
        return new Transaction(GuidGenerator.Create(),CurrentTenant.Id,DateTime.Now)
        {
            SenderIban = senderIban,
            ReceiverIban = receiverIban,
            Balance = balance,
            TransactionTypeId = transactionTypeId
        };
    }
}