﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BankManagement.EntityFrameworkCore;

public class BankManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<BankManagementHttpApiHostMigrationsDbContext>
{
    public BankManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
    {
        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<BankManagementHttpApiHostMigrationsDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"), 
                opts => { opts.UseNetTopologySuite(); });

        return new BankManagementHttpApiHostMigrationsDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
