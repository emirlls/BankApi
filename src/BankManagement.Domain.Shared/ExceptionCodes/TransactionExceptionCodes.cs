namespace BankManagement.ExceptionCodes;

public class TransactionExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string CardExceptionCodesPrefix = $"{Prefix}.Transaction";
    public const string NotFound = $"{CardExceptionCodesPrefix}:00001";
    public const string AlreadyExists = $"{CardExceptionCodesPrefix}:00002";
}