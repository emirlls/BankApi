using Volo.Abp.Modularity;

namespace BankManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class BankManagementApplicationTestBase<TStartupModule> : BankManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
