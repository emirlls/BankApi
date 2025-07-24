using Volo.Abp;
using Volo.Abp.Modularity;

namespace BankManagement.Workers;

[DependsOn(
    typeof(BankManagementDomainModule),
    typeof(BankManagementApplicationContractsModule),
    typeof(BankManagementApplicationModule))]

public class BankManagementWorkerModule:AbpModule
{
    public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        //await context.AddBackgroundWorkerAsync<TestWorker>();
    }
}