using BankManagement.BackgroundJobs;
using BankManagement.Constants;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.Threading;

namespace BankManagement.Workers.Workers;

public class TransactionWorker : AsyncPeriodicBackgroundWorkerBase
{
    private readonly IConfiguration _configuration;
    public TransactionWorker(AbpAsyncTimer timer, 
        IServiceScopeFactory serviceScopeFactory, 
        IConfiguration configuration
    ) : base(timer, serviceScopeFactory)
    {
        _configuration = configuration;
        Timer.Period = 24 * 60 * 60 * 1000;
    }

    protected override async Task DoWorkAsync(PeriodicBackgroundWorkerContext workerContext)
    {
        if (!_configuration.GetSection(BackgroundJobSettingsConstants.Transaction).Get<bool>())
        {
            return;
        }

        var transactionJob = workerContext.ServiceProvider.GetRequiredService<TransactionBackgroundJob>();
        await transactionJob.LogTransactionToElasticAsync();
    }
}