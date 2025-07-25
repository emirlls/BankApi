using System;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Repositories.ElasticSearchs;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;

namespace BankManagement.DistributedEvents.Transactions;

public class TransactionDeleteEventHandler : IDistributedEventHandler<TransactionDeleteEto>, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public TransactionDeleteEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleEventAsync(TransactionDeleteEto eventData)
    {
        var esTransactionRepository = _serviceProvider.GetRequiredService<IEsTransactionRepository>();
        await esTransactionRepository.DeleteDocumentAsync(eventData.Id,
            ElasticSearchConstants.Transaction.TransactionIndex);
    }
}