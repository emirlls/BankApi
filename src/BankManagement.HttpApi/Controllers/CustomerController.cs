using System;
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
    [CacheManagement<CustomerCreateDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _customerService.GetListAsync(cancellationToken);
    }

    /// <summary>
    /// Using to get customer with identity number
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<CustomerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _customerService.GetByIdAsync(id, cancellationToken);
    }

    /// <summary>
    /// Using to create a customer
    /// </summary>
    /// <param name="customerCreateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [CacheClear<CustomerCreateDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<bool> CreateAsync(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken = default)
    {
        return await _customerService.CreateAsync(customerCreateDto, cancellationToken);
    }


    /// <summary>
    /// Using to update a customer that given his identity number
    /// </summary>
    /// <param name="id"></param>
    /// <param name="customerUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{identityNumber}")]
    [CacheClear<CustomerCreateDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<bool> UpdateAsync(Guid id, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _customerService.UpdateAsync(id, customerUpdateDto, cancellationToken);
    }


    /// <summary>
    /// Using to delete a customer that given his identity number
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{identityNumber}")]
    [CacheClear<CustomerCreateDto>(CacheModelConstants.CustomerCacheModel)]
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _customerService.DeleteAsync(id, cancellationToken);
    }
}