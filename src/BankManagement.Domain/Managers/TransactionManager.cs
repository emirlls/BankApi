using BankManagement.Entities;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public class TransactionManager:DomainService
{
    public TransactionManager()
    {
        
    }

    public Transaction Create(string senderIban,string receiverIban,float balance,int transactionTypeId)
    {
        return new Transaction(GuidGenerator.Create())
        {
            SenderIban = senderIban,
            ReceiverIban = receiverIban,
            Balance = balance,
            TransactionTypeId = transactionTypeId
        };
    }

}