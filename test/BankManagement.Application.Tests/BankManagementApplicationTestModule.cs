using Volo.Abp.Modularity;

namespace BankManagement;

[DependsOn(
    typeof(BankManagementApplicationModule),
    typeof(BankManagementDomainTestModule)
    )]
public class BankManagementApplicationTestModule : AbpModule
{

}
