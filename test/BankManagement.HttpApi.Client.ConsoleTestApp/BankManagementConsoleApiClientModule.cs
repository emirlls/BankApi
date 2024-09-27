using Volo.Abp.Autofac;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BankManagement;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(BankManagementHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
    )]
public class BankManagementConsoleApiClientModule : AbpModule
{

}
