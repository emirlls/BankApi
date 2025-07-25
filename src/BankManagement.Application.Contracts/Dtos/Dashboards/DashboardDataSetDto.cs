using System.Collections.Generic;

namespace BankManagement.Dtos.Dashboards;

public class DashboardDataSetDto
{
    public string? Label { get; set; }

    public string BackgroundColor { get; set; }

    public List<object> Data { get; set; }
}