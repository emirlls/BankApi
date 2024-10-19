using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Transactions;
using BankManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BankManagement.Controllers;

//[Authorize]
[ApiController]
[Route("api/bank-management/transactions")]
public class TransactionController:AbpControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet("get-list")]
    public async Task<List<TransactionDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _transactionService.GetListAsync(cancellationToken);
    }

    [HttpGet("get-by-id")]
    public async Task<TransactionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _transactionService.GetByIdAsync(id, cancellationToken);
    }

    [HttpPost]
    public async Task<TransactionDto> CreateAsync(TransactionCreateDto transactionCreateDto,
        CancellationToken cancellationToken = default)
    {
        return await _transactionService.CreateAsync(transactionCreateDto, cancellationToken);
    }
}