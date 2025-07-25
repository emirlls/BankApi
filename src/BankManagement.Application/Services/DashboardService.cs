using System;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Dashboards;
using BankManagement.Models.Dashboards;
using BankManagement.Repositories.ElasticSearchs;

namespace BankManagement.Services;

public class DashboardService : BankManagementAppService, IDashboardService
{
    private readonly IEsTransactionRepository _esTransactionRepository;

    public DashboardService(IEsTransactionRepository esTransactionRepository)
    {
        _esTransactionRepository = esTransactionRepository;
    }

    public async Task<DashboardDto> GetDailyTransactionAsync(DateTime? date, CancellationToken cancellationToken)
    {
        var dailyTransactionDashboardModel =
            await _esTransactionRepository.GetDailyTransactionCountAsync(date, cancellationToken);
        var response = ObjectMapper.Map<DailyTransactionCountModel, DashboardDto>(dailyTransactionDashboardModel);
        return response;
    }
}