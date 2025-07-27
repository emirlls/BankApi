using System;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Extensions;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagement.BackgroundJobs;

public class TransactionBackgroundJob : BankManagementAppService
{
    private readonly IServiceProvider _serviceProvider;

    public TransactionBackgroundJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }


    public async Task LogTransactionToElasticAsync()
    {
        try
        {
            var transactionRepository = _serviceProvider.GetRequiredService<ITransactionRepository>();
            await _serviceProvider.LogModelsToElasticAsync<Transaction, TransactionElasticModel>(transactionRepository,
                ElasticSearchConstants.Transaction.TransactionIndex, true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}