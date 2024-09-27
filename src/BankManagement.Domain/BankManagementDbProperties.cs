namespace BankManagement;

public static class BankManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "BankManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "BankManagement";
}
