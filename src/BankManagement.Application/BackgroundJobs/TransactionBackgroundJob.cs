using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Models.ElasticSearchModel;
using BankManagement.Repositories;
using Nest;

namespace BankManagement.BackgroundJobs;

public class TransactionBackgroundJob : BankManagementAppService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly ElasticClient _elasticClient;

    public TransactionBackgroundJob(
        ITransactionRepository transactionRepository,
        ElasticClient elasticClient
    )
    {
        _transactionRepository = transactionRepository;
        _elasticClient = elasticClient;
    }


    public async Task LogTransactionToElasticAsync()
    {
        try
        {
            var oldTransactions = await _transactionRepository
                .GetListAsync(x => x.CreationTime < DateTime.Today.Date);
            var transactionElasticModel =
                ObjectMapper.Map<List<Transaction>, List<TransactionElasticModel>>(oldTransactions);
            await _elasticClient.DeleteByQueryAsync<TransactionElasticModel>(q =>
                q.Index(ElasticSearchConstants.Transaction.TransactionIndex)
                    .Query(q => q.MatchAll())
            );
            await _elasticClient.IndexManyAsync(transactionElasticModel,
                ElasticSearchConstants.Transaction.TransactionIndex);
            await _transactionRepository.DeleteManyAsync(oldTransactions);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}