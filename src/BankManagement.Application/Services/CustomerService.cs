using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Entities;
using BankManagement.Interfaces;
using BankManagement.Managers;
using BankManagement.Repositories;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class CustomerService:ApplicationService,ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly CustomerManager _customerManager;

    public CustomerService(ICustomerRepository customerRepository, CustomerManager customerManager)
    {
        _customerRepository = customerRepository;
        _customerManager = customerManager;
    }

    public async Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default)
    {
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
}