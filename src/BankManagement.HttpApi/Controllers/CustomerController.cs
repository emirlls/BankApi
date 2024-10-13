using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Interfaces;
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

    [HttpPost]
    public async Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default)
    {
        return await _customerService.CreateAsync(customerDto, cancellationToken);
    }
}