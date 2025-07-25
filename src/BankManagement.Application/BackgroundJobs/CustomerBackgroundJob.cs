using System;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.Entities;
using BankManagement.Extensions;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BankManagement.BackgroundJobs;

public class CustomerBackgroundJob: BankManagementAppService
{
    private readonly IServiceProvider _serviceProvider;

    public CustomerBackgroundJob(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public async Task LogCustomerToElasticAsync()
    {
        try
        {
            var customerRepository = _serviceProvider.GetRequiredService<ICustomerRepository>();
            await _serviceProvider.LogModelsToElasticAsync<Customer, CustomerElasticModel>(customerRepository,
                ElasticSearchConstants.Customer.CustomerIndex);
            
            var accountRepository = _serviceProvider.GetRequiredService<IAccountRepository>();
            await _serviceProvider.LogModelsToElasticAsync<Account, AccountElasticModel>(accountRepository,
                ElasticSearchConstants.Account.AccountIndex);
            
            var cardRepository = _serviceProvider.GetRequiredService<ICardRepository>();
            await _serviceProvider.LogModelsToElasticAsync<Card, CardElasticModel>(cardRepository,
                ElasticSearchConstants.Card.CardIndex);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}