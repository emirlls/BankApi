using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace BankManagement;

[DependsOn(
    typeof(BankManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class BankManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(BankManagementApplicationContractsModule).Assembly,
            BankManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<BankManagementHttpApiClientModule>();
        });

    }
}
