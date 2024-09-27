using BankManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BankManagement;

public abstract class BankManagementController : AbpControllerBase
{
    protected BankManagementController()
    {
        LocalizationResource = typeof(BankManagementResource);
    }
}
