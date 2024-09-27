using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace BankManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(BankManagementDomainSharedModule)
)]
public class BankManagementDomainModule : AbpModule
{

}
