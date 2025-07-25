using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Models.Dashboards;
using BankManagement.Models.ElasticSearchs;

namespace BankManagement.Repositories.ElasticSearchs;

public interface IEsTransactionRepository : IElasticSearchRepository<TransactionElasticModel, Guid>
{
    Task<DailyTransactionCountModel> GetDailyTransactionCountAsync(DateTime? date, CancellationToken cancellationToken);
    Task<List<TransactionElasticModel>> GetTransactionsAsync(DateTime? date, CancellationToken cancellationToken);
}