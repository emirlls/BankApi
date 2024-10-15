using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Customers;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class CustomerService:ApplicationService,ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerManager _customerManager;
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;

    public CustomerService(ICustomerRepository customerRepository, CustomerManager customerManager, IStringLocalizer<BankManagementResource> stringLocalizer)
    {
        _customerRepository = customerRepository;
        _customerManager = customerManager;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default)
    {
        var alreadyExists = await _customerRepository.FindAsync(
            x => x.IdentityNumber.Equals(customerDto.IdentityNumber), cancellationToken: cancellationToken);
        
        if (alreadyExists != null)
        {
            throw new UserFriendlyException(_stringLocalizer[CustomerExceptionCodes.AlreadyExists]);
        }
        var customer = _customerManager.Create(
            customerDto.IdentityNumber, 
            customerDto.Name, 
            customerDto.Surname,
            customerDto.Mail, 
            customerDto.Phone, 
            customerDto.Birthday);

        await _customerRepository.InsertAsync(customer, cancellationToken: cancellationToken);
        
        return ObjectMapper.Map<Customer, CustomerDto>(customer);
        
    }

    public async Task<CustomerDto> UpdateAsync(string identityNumber, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetAsync(x => x.IdentityNumber.Equals(identityNumber),cancellationToken:cancellationToken);
        if (customer == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CustomerExceptionCodes.NotFound]);
        }

        var newCustomer = _customerManager.Update(customer,customerUpdateDto.Name, customerUpdateDto.Surname,
            customerUpdateDto.Phone, customerUpdateDto.Mail);
        await _customerRepository.UpdateAsync(customer, cancellationToken: cancellationToken);
        return ObjectMapper.Map<Customer, CustomerDto>(newCustomer);
    }

    public async Task<bool> DeleteAsync(string identityNumber, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetAsync(x => x.IdentityNumber.Equals(identityNumber),
            cancellationToken: cancellationToken);
        if (customer == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CustomerExceptionCodes.NotFound]);
        }

        await _customerRepository.DeleteAsync(customer);
        return true;
    }

    public async Task<CustomerDto> GetByIdAsync(string identityNumber, CancellationToken cancellationToken = default)
    {
        var customer = await _customerRepository.GetAsync(x => x.IdentityNumber.Equals(identityNumber),
            cancellationToken: cancellationToken);
        if (customer == null)
        {
            throw new UserFriendlyException(_stringLocalizer[CustomerExceptionCodes.NotFound]);
        }

        return ObjectMapper.Map<Customer, CustomerDto>(customer);
    }

    public async Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var customers = await _customerRepository.GetListAsync(cancellationToken: cancellationToken);
        return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
    }
}