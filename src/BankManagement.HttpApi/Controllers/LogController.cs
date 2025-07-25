using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.ElasticLogs;
using BankManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers;

//[Authorize]
[ApiController]
[Route("api/bank-management/logs")]
public class LogController: BankManagementController
{
    private readonly ILogService _logService;

    public LogController(ILogService logService)
    {
        _logService = logService;
    }
    
    /// <summary>
    /// Created to get list of transaction logs on elastic search
    /// It takes a date parameter.
    /// If the parameter is empty, the default value is this month.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("elastic-transactions")]
    public async Task<List<ElasticLogDto>> GetTransactionElasticLogsAsync(
        DateTime? dateTime,
        CancellationToken cancellationToken = default
    )
    {
        return await _logService.GetTransactionElasticLogsAsync(dateTime, cancellationToken);
    }
}