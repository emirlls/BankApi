using BankManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BankManagement.Permissions;

public class BankManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(BankManagementPermissions.GroupName, L("Permission:BankManagement"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<BankManagementResource>(name);
    }
}
