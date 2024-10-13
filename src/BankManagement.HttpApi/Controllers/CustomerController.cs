using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
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
    /// Using for create a customer
    /// </summary>
    /// <param name="customerDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default)
    {
        return await _customerService.CreateAsync(customerDto, cancellationToken);
    }

    
    /// <summary>
    /// Using for update a customer that given his identity number
    /// </summary>
    /// <param name="identityNumber"></param>
    /// <param name="customerUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<CustomerDto> UpdateAsync(string identityNumber, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _customerService.UpdateAsync(identityNumber, customerUpdateDto, cancellationToken);
    }

    
    /// <summary>
    /// Using for delete a customer that given his identity number
    /// </summary>
    /// <param name="identityNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete]
    public async Task<bool> DeleteAsync(string identityNumber, CancellationToken cancellationToken = default)
    {
        return await _customerService.DeleteAsync(identityNumber, cancellationToken);
    }

    
    /// <summary>
    /// Using for get a customer that given his identity number
    /// </summary>
    /// <param name="identityNumber"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("/get-by-id")]
    public async Task<CustomerDto> GetByIdAsync(string identityNumber, CancellationToken cancellationToken = default)
    {
        return await _customerService.GetByIdAsync(identityNumber, cancellationToken);
    }
    
    
    /// <summary>
    /// Using for customer list
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("/get-customers-list")]
    public async Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _customerService.GetListAsync(cancellationToken);
    }
}