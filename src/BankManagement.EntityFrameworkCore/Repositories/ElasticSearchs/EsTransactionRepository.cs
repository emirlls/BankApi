using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Models.Dashboards;
using BankManagement.Models.ElasticSearchs;

namespace BankManagement.Repositories.ElasticSearchs;

public class EsTransactionRepository : ElasticSearchRepository<TransactionElasticModel, Guid>, IEsTransactionRepository
{
    public EsTransactionRepository(IServiceProvider serviceProvider) : base(serviceProvider)
    {
    }

    public async Task<DailyTransactionCountModel> GetDailyTransactionCountAsync(DateTime? date, CancellationToken cancellationToken)
    {
        var targetDate = date ?? DateTime.Today;
        var startDate = new DateTime(targetDate.Year, targetDate.Month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);
        var searchResponse = await GetCreationTimeFilteredBetweenAsync<TransactionElasticModel>(
            startDate, 
            endDate,
            ElasticSearchConstants.Transaction.TransactionIndex,
            x=>x.CreationTime,
            cancellationToken);
        
        var groupedByDay = searchResponse
            .GroupBy(x => x.CreationTime.Date)
            .ToDictionary(g => g.Key, g => g.Count());

        var allDays = Enumerable.Range(0, (endDate - startDate).Days + 1)
            .Select(offset => startDate.AddDays(offset))
            .ToList();

        var completedData = allDays
            .Select(day => new
            {
                Date = day,
                Count = groupedByDay.TryGetValue(day, out var count) ? count : 0
            })
            .OrderBy(x => x.Date)
            .ToList();

        return new DailyTransactionCountModel
        {
            Days = completedData.Select(x => x.Date.ToString("dd.MM.yyyy")).ToList(),
            Count = completedData.Select(x => x.Count).ToList()
        };
    }

    public async Task<List<TransactionElasticModel>> GetTransactionsAsync(DateTime? date, CancellationToken cancellationToken)
    {
        var targetDate = date ?? DateTime.Today;
        var startDate = new DateTime(targetDate.Year, targetDate.Month, 1);
        var endDate = startDate.AddMonths(1).AddDays(-1);
        var searchResponse = await GetCreationTimeFilteredBetweenAsync<TransactionElasticModel>(
            startDate, 
            endDate,
            ElasticSearchConstants.Transaction.TransactionIndex,
            x=>x.CreationTime,
            cancellationToken);
        return searchResponse.ToList();
    }
}