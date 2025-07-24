namespace BankManagement.Models.ElasticSearchModel;

public class TransactionElasticModel
{
    public string SenderIban { get; set; }
    public string ReceiverIban { get; set; }
    public float Balance { get; set; }
    public int TransactionTypeId { get; set; }
}