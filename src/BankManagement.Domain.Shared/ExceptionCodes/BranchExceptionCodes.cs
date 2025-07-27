namespace BankManagement.ExceptionCodes;

public class BranchExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string AccountExceptionCodesPrefix = $"{Prefix}.Branch";
    public const string NotFound = $"{AccountExceptionCodesPrefix}:00001";
}