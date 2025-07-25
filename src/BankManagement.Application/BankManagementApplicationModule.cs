using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp.EventBus.RabbitMq;

namespace BankManagement;

[DependsOn(
    typeof(BankManagementDomainModule),
    typeof(BankManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule),
    typeof(AbpEventBusRabbitMqModule)
    )]
public class BankManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<BankManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BankManagementApplicationModule>(validate: true);
        });
    }
}
