namespace BankManagement.ExceptionCodes;

public class CustomerExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string CustomerExceptionCodesPrefix = $"{Prefix}.Customer";
    public const string NotFound = $"{CustomerExceptionCodesPrefix}:00001";
    public const string AlreadyExists = $"{CustomerExceptionCodesPrefix}:00002";
}