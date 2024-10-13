namespace BankManagement.ExceptionCodes;

public static class CustomerExceptionCodes
{
    private const string Prefix = "BankManagement";
    private const string CustomerExceptionCodesPrefix = $"{Prefix}.Customer";
    public const string NotFound = $"{CustomerExceptionCodesPrefix}:00001";
    public const string AlreadyExists = $"{CustomerExceptionCodesPrefix}:00002";
    
    public static class IdentityNumber
    {
        private const string PrefixId = $"{CustomerExceptionCodesPrefix}.IdentityNumber";
        public const string CannotBeEmpty = $"{PrefixId}:00001";
        public const string MaxLength = $"{PrefixId}:00002";
    }
    public static class Name
    {
        private const string PrefixId = $"{CustomerExceptionCodesPrefix}.Name";
        public const string CannotBeEmpty = $"{PrefixId}:00001";
    }
    public static class Surname
    {
        private const string PrefixId = $"{CustomerExceptionCodesPrefix}.Surname";
        public const string CannotBeEmpty = $"{PrefixId}:00001";
    }
    public static class Phone
    {
        private const string PrefixId = $"{CustomerExceptionCodesPrefix}.Phone";
        public const string CannotBeEmpty = $"{PrefixId}:00001";
        public const string MaxLength = $"{PrefixId}:00002";
    }
    public static class BirthDay
    {
        private const string PrefixId = $"{CustomerExceptionCodesPrefix}.BirthDay";
        public const string CannotBeEmpty = $"{PrefixId}:00001";
    }
}