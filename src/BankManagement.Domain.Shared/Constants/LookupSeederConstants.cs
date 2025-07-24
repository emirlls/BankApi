namespace BankManagement.Constants;

public static class LookupSeederConstants
{
    public static class CardTypes
    {
        public const string Bank = "42f63785-93f9-4b53-9038-9499455d9cd5";
        public const string Credit = "ea9295a9-610d-41b1-8c95-8766b8ec4055";
    }

    public static class AccountTypes
    {
        public const string Deposite = "3018286c-3eb3-4710-a2ea-a82948c80596";
        public const string Checking = "d2333569-8720-4f19-97b3-ef8d7d1f19d1";
    }
    
    public static class TransactionTypes
    {
        public const string ToAccount = "6707cd60-afa6-4be8-ad69-53436ae92aa3";
        public const string ToCard = "586dee74-6c05-4f4f-bd00-51724d0fe571";
    }
}