using System;
using System.Collections.Generic;

namespace BankManagement.Dtos.Dashboards;

public class DashboardDto
{
    public DateTime LastUpdateTime { get; set; } = DateTime.Now;

    public List<string> Labels { get; set; }

    public List<DashboardDataSetDto> DataSets { get; set; }
}