namespace BankManagement.ExceptionCodes;

public class AccountExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string AccountExceptionCodesPrefix = $"{Prefix}.Account";
    public const string NotFound = $"{AccountExceptionCodesPrefix}:00001";
    public const string AlreadyExists = $"{AccountExceptionCodesPrefix}:00002";
    
    public static class Iban
    {
        private const string PrefixIban = $"{AccountExceptionCodesPrefix}.Iban";
        public const string CannotBeEmpty = $"{PrefixIban}:00001";
        public const string AlreadyExists = $"{PrefixIban}:00002";
    }
}