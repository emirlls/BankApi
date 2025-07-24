namespace BankManagement.Constants;

public class ElasticSearchConstants
{
    public const string ElasticsearchOptions = nameof(ElasticsearchOptions);
    
    public static class Transaction
    {
        public const string TransactionIndex = "bank-management-transaction-index";
        public const int ElasticPageSize = 999999999;
    }
}