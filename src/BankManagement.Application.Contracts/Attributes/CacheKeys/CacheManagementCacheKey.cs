namespace BankManagement.Attributes.CacheKeys;

public class CacheManagementCacheKey
{
    public string CacheKey { get; set; }

    public CacheManagementCacheKey(string cacheKey)
    {
        CacheKey = cacheKey;
    }

    public override string ToString()
    {
        return $"bnk_{CacheKey}";
    }
}