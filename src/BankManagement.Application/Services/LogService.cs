using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.ElasticLogs;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Repositories.ElasticSearchs;

namespace BankManagement.Services;

public class LogService : BankManagementAppService, ILogService
{
    private readonly IEsTransactionRepository _esTransactionRepository;

    public LogService(IEsTransactionRepository esTransactionRepository)
    {
        _esTransactionRepository = esTransactionRepository;
    }

    public async Task<List<ElasticLogDto>> GetTransactionElasticLogsAsync(DateTime? dateTime, CancellationToken cancellationToken)
    {
        var transactionElasticModel =
            await _esTransactionRepository.GetTransactionsAsync(dateTime, cancellationToken);
        var response = ObjectMapper.Map<List<TransactionElasticModel>, List<ElasticLogDto>>(transactionElasticModel);
        return response;
    }
}