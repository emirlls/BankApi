using Localization.Resources.AbpUi;
using BankManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagement;

[DependsOn(
    typeof(BankManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class BankManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(BankManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<BankManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
