namespace BankManagement.Constants;

public class ElasticSearchConstants
{
    public const string ElasticsearchOptions = nameof(ElasticsearchOptions);
    public const int ElasticPageSize = 999999999;
    public const string DefaultIndex = "default";
    public const string IdPropertyName = "id";


    public static class Transaction
    {
        public const string TransactionIndex = "bank-management-transaction-index";
    }

    public static class Customer
    {
        public const string CustomerIndex = "bank-management-customer-index";
    }
    
    public static class Account
    {
        public const string AccountIndex = "bank-management-account-index";
    }
    
    public static class Card
    {
        public const string CardIndex = "bank-management-card-index";
    }
}