using System;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Dashboards;
using BankManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers;

//[Authorize]
[ApiController]
[Route("api/bank-management/dashboards")]
public class DashboardController : BankManagementController
{
    private readonly IDashboardService _dashboardService;

    public DashboardController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }
    
    /// <summary>
    /// Created to display daily transfer count in specific month on the dashboard.
    /// It takes a date parameter.
    /// If the parameter is empty, the default value is this month.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<DashboardDto> GetDailyTransactionAsync(DateTime? date,
        CancellationToken cancellationToken = default)
    {
        return await _dashboardService.GetDailyTransactionAsync(date, cancellationToken);
    }
}