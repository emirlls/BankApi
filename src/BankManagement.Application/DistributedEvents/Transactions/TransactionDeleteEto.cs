using System;
using Volo.Abp.Domain.Entities.Events.Distributed;
using Volo.Abp.EventBus;

namespace BankManagement.DistributedEvents.Transactions;

[EventName("BankManagement.DeleteTransaction")]
public class TransactionDeleteEto : EtoBase
{
    public Guid Id { get; set; }
}