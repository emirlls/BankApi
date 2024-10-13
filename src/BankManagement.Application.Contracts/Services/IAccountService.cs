using System;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface IAccountService:IApplicationService
{
    public Task<AccountDto> CreateAsync(
        AccountCreateDto accountCreateDto,
        CancellationToken cancellationToken=default);
    public Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default);
}