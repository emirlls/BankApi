using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Attributes;
using BankManagement.Constants;
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

    /// <summary>
    /// Used to get list of transactions
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    [CacheManagement<TransactionDto>(CacheModelConstants.TransactionCacheModel)]
    public async Task<List<TransactionDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _transactionService.GetListAsync(cancellationToken);
    }

    /// <summary>
    /// Used to get the transaction with id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public async Task<TransactionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _transactionService.GetByIdAsync(id, cancellationToken);
    }

    /// <summary>
    /// Used to create transaction
    /// </summary>
    /// <param name="transactionCreateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    [CacheClear<TransactionDto>(CacheModelConstants.TransactionCacheModel)]
    public async Task<TransactionDto> CreateAsync(TransactionCreateDto transactionCreateDto,
        CancellationToken cancellationToken = default)
    {
        return await _transactionService.CreateAsync(transactionCreateDto, cancellationToken);
    }
}