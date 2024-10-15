namespace BankManagement.ExceptionCodes;

public class CardExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string CardExceptionCodesPrefix = $"{Prefix}.Card";
    public const string NotFound = $"{CardExceptionCodesPrefix}:00001";
    public const string AlreadyExists = $"{CardExceptionCodesPrefix}:00002";
}