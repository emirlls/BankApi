using System.Collections.Generic;

namespace BankManagement.Models.Dashboards;

public class DailyTransactionCountModel
{
    public List<string> Days { get; set; }
    public List<int> Count { get; set; }
}