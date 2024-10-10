using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using Volo.Abp.Application.Services;

namespace BankManagement.Interfaces;

public interface ICustomerService:IApplicationService
{
    public Task<CustomerDto> CreateAsync(CustomerDto customerDto, CancellationToken cancellationToken = default);
}