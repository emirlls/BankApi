using BankManagement.Constants;
using Volo.Abp.AuditLogging;
using Volo.Abp.Data;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace BankManagement.Extensions;

public class ServiceConfigurationContextExtension
{
    public static void ResolveSchemaAndPrefix()
    {
        // common schema and prefix override:
        AbpCommonDbProperties.DbSchema = BankManagementDatabaseConstants.SchemaName;
        AbpCommonDbProperties.DbTablePrefix = string.Empty;
        // setting management schema and prefix override:
        AbpSettingManagementDbProperties.DbSchema = DatabaseConstants.
            SettingManagementSchema;
        AbpSettingManagementDbProperties.DbTablePrefix = string.Empty;
        // permission management schema and prefix override:
        AbpPermissionManagementDbProperties.DbSchema = DatabaseConstants.
            CommonSchema;
        AbpPermissionManagementDbProperties.DbTablePrefix = string.Empty;
        // tenant management schema and prefix override:
        AbpTenantManagementDbProperties.DbSchema = DatabaseConstants.
            CommonSchema;
        AbpTenantManagementDbProperties.DbTablePrefix = string.Empty;
        // audit management schema and prefix override:
        AbpAuditLoggingDbProperties.DbSchema = DatabaseConstants.
            AuditLoggingSchema;
        AbpAuditLoggingDbProperties.DbTablePrefix = string.Empty;
        // identity schema and prefix override:
        AbpIdentityDbProperties.DbSchema = DatabaseConstants.CommonSchema;
        AbpIdentityDbProperties.DbTablePrefix = string.Empty;
        // open iddict schema and prefix override:
        AbpOpenIddictDbProperties.DbSchema = DatabaseConstants.OpenIddictSchema;
        AbpOpenIddictDbProperties.DbTablePrefix = string.Empty;
        // feature management schema and prefix override:
        AbpFeatureManagementDbProperties.DbSchema = DatabaseConstants.
            CommonSchema;
        AbpFeatureManagementDbProperties.DbTablePrefix = string.Empty;
    }

}