using Volo.Abp.Modularity;

namespace BankManagement;

[DependsOn(
    typeof(BankManagementDomainModule),
    typeof(BankManagementTestBaseModule)
)]
public class BankManagementDomainTestModule : AbpModule
{

}
