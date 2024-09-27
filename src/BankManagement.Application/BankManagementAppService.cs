using BankManagement.Localization;
using Volo.Abp.Application.Services;

namespace BankManagement;

public abstract class BankManagementAppService : ApplicationService
{
    protected BankManagementAppService()
    {
        LocalizationResource = typeof(BankManagementResource);
        ObjectMapperContext = typeof(BankManagementApplicationModule);
    }
}
