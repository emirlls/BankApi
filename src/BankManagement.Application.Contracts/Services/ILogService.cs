using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.ElasticLogs;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface ILogService: IApplicationService
{
    Task<List<ElasticLogDto>> GetTransactionElasticLogsAsync(DateTime? dateTime, CancellationToken cancellationToken);
}