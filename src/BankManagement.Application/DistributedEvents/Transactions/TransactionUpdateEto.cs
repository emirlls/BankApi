using BankManagement.Entities;
using BankManagement.Models.Transactions;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace BankManagement.DistributedEvents.Transactions;

[EventName("BankManagement.UpdateTransaction")]
public class TransactionUpdateEto : EtoBase
{
    public TransactionEventModel TransactionEventModel { get; set; }
}