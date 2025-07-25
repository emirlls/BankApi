using System;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Dashboards;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface IDashboardService : IApplicationService
{
    Task<DashboardDto> GetDailyTransactionAsync(DateTime? date, CancellationToken cancellationToken);
}