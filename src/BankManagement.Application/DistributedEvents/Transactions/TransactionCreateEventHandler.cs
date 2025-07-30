using System;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Extensions;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Models.Transactions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace BankManagement.DistributedEvents.Transactions;

public class TransactionCreateEventHandler : IDistributedEventHandler<TransactionCreateEto>, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public TransactionCreateEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleEventAsync(TransactionCreateEto eventData)
    {
        await _serviceProvider.LogModelToElasticAsync<TransactionEventModel, TransactionElasticModel>(eventData.TransactionEventModel,
            ElasticSearchConstants.Transaction.TransactionIndex);
    }
}