using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Customers;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface ICustomerService:IApplicationService
{
    public Task<bool> CreateAsync(CustomerCreateDto customerCreateDto, CancellationToken cancellationToken = default);

    public Task<bool> UpdateAsync(Guid id, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<CustomerDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default);
}