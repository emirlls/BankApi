using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Customers;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface ICustomerService:IApplicationService
{
    public Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default);

    public Task<CustomerDto> UpdateAsync(string identityNumber, CustomerUpdateDto customerUpdateDto,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(string identityNumber, CancellationToken cancellationToken = default);

    public Task<CustomerDto> GetByIdAsync(string identityNumber, CancellationToken cancellationToken = default);

    public Task<List<CustomerDto>> GetListAsync(CancellationToken cancellationToken = default);
}