using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using BankManagement.Attributes.CacheKeys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Caching;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Attributes;

public class CacheClearAttribute<TCacheItem> : ActionFilterAttribute
    where TCacheItem : class
{
    public string CacheKey { get; set; }
    public CacheClearAttribute(string cacheKey)
    {
        CacheKey = cacheKey;
    }

    
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var serviceProvider = context.HttpContext.RequestServices;
        var distributedCache = serviceProvider.GetRequiredService<IDistributedCache<TCacheItem,CacheManagementCacheKey>>();
        var currentTenant = serviceProvider.GetRequiredService<ICurrentTenant>();
        var currentTenantId = currentTenant.Id;
        var queryParams = context.HttpContext.Request.Query
            .OrderBy(q => q.Key)
            .Select(q => $"{q.Key}={q.Value}");

        var queryString = string.Join("&", queryParams);

        var cacheKey = GenerateCacheKey(
            CultureInfo.CurrentCulture,
            CacheKey,
            queryString,
            currentTenantId
        );

        var executedContext = await next();

        if (executedContext.Result is ObjectResult { Value: TCacheItem item })
        {
            await distributedCache.RemoveAsync(new CacheManagementCacheKey(cacheKey));
        }
    }
    private string GenerateCacheKey(CultureInfo cultureInfo, string cacheKey,string? queryParams, Guid? tenantId)
    {
        return
            $"{tenantId}_{cultureInfo.Name}_{queryParams}_{cacheKey}";
    }
}