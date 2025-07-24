using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Attributes;
using BankManagement.Constants;
using BankManagement.Dtos.Customers;
using BankManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BankManagement.Controllers;


//[Authorize]
[ApiController]
[Route("api/bank-management/customers")]
public class CustomerController:AbpControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    /// <summary>
    /// Using to get list of customers
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [CacheManagement<CustomerDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _customerService.GetListAsync(cancellationToken);
    }
    
    /// <summary>
    /// Using to get customer with identity number
    /// </summary>
    /// <param name="identityNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{identityNumber}")]
    public async Task<CustomerDto> GetByIdAsync(string identityNumber, CancellationToken cancellationToken = default)
    {
        return await _customerService.GetByIdAsync(identityNumber, cancellationToken);
    }

    /// <summary>
    /// Using to create a customer
    /// </summary>
    /// <param name="customerDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [CacheClear<CustomerDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default)
    {
        return await _customerService.CreateAsync(customerDto, cancellationToken);
    }

    
    /// <summary>
    /// Using to update a customer that given his identity number
    /// </summary>
    /// <param name="identityNumber"></param>
    /// <param name="customerUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{identityNumber}")]
    [CacheClear<CustomerDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<CustomerDto> UpdateAsync(string identityNumber, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _customerService.UpdateAsync(identityNumber, customerUpdateDto, cancellationToken);
    }

    
    /// <summary>
    /// Using to delete a customer that given his identity number
    /// </summary>
    /// <param name="identityNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{identityNumber}")]
    [CacheClear<CustomerDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<bool> DeleteAsync(string identityNumber, CancellationToken cancellationToken = default)
    {
        return await _customerService.DeleteAsync(identityNumber, cancellationToken);
    }
}