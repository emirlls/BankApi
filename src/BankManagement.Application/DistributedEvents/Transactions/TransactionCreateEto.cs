using BankManagement.Entities;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace BankManagement.DistributedEvents.Transactions;

[EventName("BankManagement.CreateTransaction")]
public class TransactionCreateEto : EtoBase
{
    public Transaction Transaction { get; set; }
}