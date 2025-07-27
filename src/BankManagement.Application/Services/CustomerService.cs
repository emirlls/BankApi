using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Customers;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Models.Customers;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class CustomerService : ApplicationService, ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerManager _customerManager;
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;

    public CustomerService(
        ICustomerRepository customerRepository, 
        CustomerManager customerManager,
        IStringLocalizer<BankManagementResource> stringLocalizer
    )
    {
        _customerRepository = customerRepository;
        _customerManager = customerManager;
        _stringLocalizer = stringLocalizer;
    }
    public async Task<bool> CreateAsync(CustomerCreateDto customerCreateDto,
        CancellationToken cancellationToken = default)
    {
        var alreadyExists = await _customerManager.TryGetByAsync(
            x => x.IdentityNumber.Equals(customerCreateDto.IdentityNumber));

        if (alreadyExists != null)
        {
            throw new UserFriendlyException(_stringLocalizer[CustomerExceptionCodes.AlreadyExists]);
        }

        var customerCreateModel = ObjectMapper.Map<CustomerCreateDto, CustomerCreateModel>(customerCreateDto);
        var customer = _customerManager.Create(customerCreateModel);

        await _customerRepository.InsertAsync(customer, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var customer = await _customerManager.TryGetByAsync(x => x.Id.Equals(id), true);
        var customerUpdateModel = ObjectMapper.Map<CustomerUpdateDto, CustomerUpdateModel>(customerUpdateDto);

        var updatedCustomer = _customerManager.Update(customer!, customerUpdateModel);
        await _customerRepository.UpdateAsync(updatedCustomer, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _customerManager.TryGetByAsync(x => x.Id.Equals(id), true);
        await _customerRepository.DeleteAsync(customer!, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<CustomerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var customer = await _customerManager.TryGetByAsync(x => x.Id.Equals(id), true);
        return ObjectMapper.Map<Customer, CustomerDto>(customer!);
    }

    public async Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var customers = await _customerRepository.GetListAsync(cancellationToken: cancellationToken);
        return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
    }
}