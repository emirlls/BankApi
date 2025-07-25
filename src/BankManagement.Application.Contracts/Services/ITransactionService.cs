using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Transactions;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface ITransactionService:IApplicationService
{
    Task<List<TransactionDto>> GetListAsync(CancellationToken cancellationToken = default);

    Task<TransactionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<bool> CreateAsync(TransactionCreateDto transactionCreateDto,
        CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Guid id, TransactionUpdateDto transactionUpdateDto,
        CancellationToken cancellationToken = default);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}