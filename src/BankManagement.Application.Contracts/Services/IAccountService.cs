using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Accounts;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface IAccountService:IApplicationService
{
    public Task<AccountDto> CreateAsync(
        AccountCreateDto accountCreateDto,
        CancellationToken cancellationToken=default);

    public Task<AccountDto> UpdateAsync(Guid id,AccountUpdateDto accountUpdateDto,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(Guid id,CancellationToken cancellationToken = default);
    public Task<List<AccountDto>> GetListAsync(CancellationToken cancellationToken);
    public Task<AccountDto> GetByIdAsync(
        Guid id, 
        CancellationToken cancellationToken = default);
}