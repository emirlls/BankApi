using System;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Repositories.ElasticSearchs;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.ObjectMapping;

namespace BankManagement.DistributedEvents.Transactions;

public class TransactionUpdateEventHandler : IDistributedEventHandler<TransactionUpdateEto>, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public TransactionUpdateEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task HandleEventAsync(TransactionUpdateEto eventData)
    {
        var esTransactionRepository = _serviceProvider.GetRequiredService<IEsTransactionRepository>();
        var objectMapper = _serviceProvider.GetRequiredService<IObjectMapper>();
        await esTransactionRepository.DeleteDocumentAsync(eventData.Transaction.Id,
            ElasticSearchConstants.Transaction.TransactionIndex);
        var transactionElasticModel = objectMapper.Map<Transaction, TransactionElasticModel>(eventData.Transaction);
        await esTransactionRepository.CreateDocumentAsync(transactionElasticModel,
            ElasticSearchConstants.Transaction.TransactionIndex);
    }
}