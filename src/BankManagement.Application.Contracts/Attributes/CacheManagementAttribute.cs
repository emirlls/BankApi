using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BankManagement.Attributes.CacheKeys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Volo.Abp.Caching;
using Volo.Abp.MultiTenancy;

namespace BankManagement.Attributes;

public class CacheManagementAttribute<TCacheItem> : ActionFilterAttribute
where TCacheItem : class
{
    public string CacheKey { get; set; }

    public CacheManagementAttribute(
        string cacheKey
    )
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
        
        var cachedItem = distributedCache.GetAsync(new CacheManagementCacheKey(cacheKey));
        DefaultContractResolver contractResolver = new DefaultContractResolver
        {
            NamingStrategy = new CamelCaseNamingStrategy()
        };
        if (cachedItem != null)
        {
            var result = new ContentResult
            {
                Content = JsonConvert.SerializeObject(cachedItem, new JsonSerializerSettings
                {
                    ContractResolver = contractResolver,
                    Formatting = Formatting.Indented
                }),
                ContentType = "application/json",
                StatusCode = (int)HttpStatusCode.OK
            };
            context.Result = result;
            return;
        }
        var executedContext = await next();

        if (executedContext.Result is ObjectResult { Value: TCacheItem item })
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(int.MaxValue)
            };
            var redisKey = new CacheManagementCacheKey(cacheKey);
            await distributedCache.SetAsync(redisKey,
                item, options);
        }
    }
    private string GenerateCacheKey(CultureInfo cultureInfo, string cacheKey,string? queryParams, Guid? tenantId)
    {
        return
            $"{tenantId}_{cultureInfo.Name}_{queryParams}_{cacheKey}";
    }
}