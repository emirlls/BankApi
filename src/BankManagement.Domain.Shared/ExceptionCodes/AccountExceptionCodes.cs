namespace BankManagement.ExceptionCodes;

public class AccountExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string AccountExceptionCodesPrefix = $"{Prefix}.Account";
    public const string NotFound = $"{AccountExceptionCodesPrefix}:00001";
    public const string AlreadyExists = $"{AccountExceptionCodesPrefix}:00002";
}