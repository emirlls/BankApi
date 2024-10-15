using System.Threading.Tasks;
using BankManagement.Extensions;
using Localization.Resources.AbpUi;
using BankManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Volo.Abp;

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
    
    public override Task OnApplicationInitializationAsync(ApplicationInitializationContext context)
    {
        GlobalLocalizationProvider.SetLocalizer(context.ServiceProvider.GetRequiredService<IStringLocalizer<BankManagementResource>>());
        return base.OnApplicationInitializationAsync(context);
    }
}
