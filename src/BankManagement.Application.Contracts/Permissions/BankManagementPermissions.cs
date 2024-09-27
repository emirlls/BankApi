using Volo.Abp.Reflection;

namespace BankManagement.Permissions;

public class BankManagementPermissions
{
    public const string GroupName = "BankManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(BankManagementPermissions));
    }
}
