using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BankManagement.Constants;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BankManagement.EntityFrameworkCore;
using BankManagement.Extensions;
using BankManagement.Models.ElasticSearchs;
using BankManagement.MultiTenancy;
using BankManagement.Repositories.ElasticSearchs;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.StackExchangeRedis;
//using StackExchange.Redis;
using Microsoft.OpenApi.Models;
using Nest;
using Volo.Abp;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Mvc.UI.MultiTenancy;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Caching;
//using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Swashbuckle;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.VirtualFileSystem;

namespace BankManagement;

[DependsOn(
    typeof(BankManagementApplicationModule),
    typeof(BankManagementEntityFrameworkCoreModule),
    typeof(BankManagementHttpApiModule),
    typeof(AbpAspNetCoreMvcUiMultiTenancyModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpAutofacModule),
    //typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class BankManagementHttpApiHostModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        base.PreConfigureServices(context);
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        ServiceConfigurationContextExtension.ResolveSchemaAndPrefix();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        Configure<AbpDbContextOptions>(options => { options.UseNpgsql(opts => { opts.UseNetTopologySuite(); }); });

        Configure<AbpDistributedEventBusOptions>(options =>
        {
            
        });
        
        Configure<AbpRabbitMqEventBusOptions>(options =>
        {
            options.ClientName = "BankManagementClient";
            options.ExchangeName = "BankManagementExchange";
        });

        Configure<RedisCacheOptions>(options =>
        {
            options.Configuration = context.Services
                .GetConfiguration()
                .GetSection("Redis")["Configuration"];
        });
        context.Services.AddSingleton<ElasticClient>(provider =>
        {
            var elasticsearchOptions = configuration.GetSection(ElasticSearchConstants.ElasticsearchOptions)
                .Get<ElasticSearchOptions>();
            var settings = new ConnectionSettings(new Uri(elasticsearchOptions.Host));
            return new ElasticClient(settings);
        });

        Configure<AbpMultiTenancyOptions>(options => { options.IsEnabled = MultiTenancyConsts.IsEnabled; });
        context.Services.AddTransient(typeof(IElasticSearchRepository<,>), typeof(ElasticSearchRepository<,>));

        if (hostingEnvironment.IsDevelopment())
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<BankManagementDomainSharedModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}BankManagement.Domain.Shared", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<BankManagementDomainModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}BankManagement.Domain", Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<BankManagementApplicationContractsModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}BankManagement.Application.Contracts",
                            Path.DirectorySeparatorChar)));
                options.FileSets.ReplaceEmbeddedByPhysical<BankManagementApplicationModule>(
                    Path.Combine(hostingEnvironment.ContentRootPath,
                        string.Format("..{0}..{0}src{0}BankManagement.Application", Path.DirectorySeparatorChar)));
            });
        }

        context.Services.AddAbpSwaggerGenWithOAuth(
            configuration["AuthServer:Authority"]!,
            new Dictionary<string, string>
            {
                { "BankManagement", "BankManagement API" }
            },
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BankManagement API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) =>
                    ConfigureSwaggerNotVisibleApis(description));
                options.CustomSchemaIds(type => type.FullName);

                var filePathHttpApi = Path.Combine(AppContext.BaseDirectory, "BankManagement.HttpApi.xml");
                var filePathHttpApiHost = Path.Combine(AppContext.BaseDirectory, "BankManagement.HttpApi.Host.xml");
                options.IncludeXmlComments(filePathHttpApi, true);
                options.IncludeXmlComments(filePathHttpApiHost, true);
            });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Languages.Add(new LanguageInfo("en", "en", "English"));
            options.Languages.Add(new LanguageInfo("tr", "tr", "Türkçe"));
        });

        context.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddAbpJwtBearer(options =>
            {
                options.Authority = configuration["AuthServer:Authority"];
                options.RequireHttpsMetadata = configuration.GetValue<bool>("AuthServer:RequireHttpsMetadata");
                options.Audience = "BankManagement";
            });

        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "BankManagement:"; });

        /*var dataProtectionBuilder = context.Services.AddDataProtection().SetApplicationName("BankManagement");
        if (!hostingEnvironment.IsDevelopment())
        {
            var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
            dataProtectionBuilder.PersistKeysToStackExchangeRedis(redis, "BankManagement-Protection-Keys");
        }*/

        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                        configuration["App:CorsOrigins"]?
                            .Split(",", StringSplitOptions.RemoveEmptyEntries)
                            .Select(o => o.RemovePostFix("/"))
                            .ToArray() ?? Array.Empty<string>()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });
    }

    private static bool ConfigureSwaggerNotVisibleApis(ApiDescription apiDescription)
    {
        return !apiDescription.RelativePath!.StartsWith("api/abp/");
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        if (MultiTenancyConsts.IsEnabled)
        {
            app.UseMultiTenancy();
        }

        app.UseAbpRequestLocalization();
        app.UseAuthorization();
        app.UseSwagger();
        app.UseAbpSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Support APP API");

            var configuration = context.GetConfiguration();
            options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
            options.OAuthScopes("BankManagement");
        });
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }
}