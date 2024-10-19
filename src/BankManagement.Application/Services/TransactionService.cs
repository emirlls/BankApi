using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Dtos.Transactions;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public class TransactionService:ApplicationService,ITransactionService
{
    private readonly IAccountRepository _accountRepository;
    private readonly ICardRepository _cardRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly TransactionManager _transactionManager;
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;

    public TransactionService(IAccountRepository accountRepository, ICardRepository cardRepository, ITransactionRepository transactionRepository, IStringLocalizer<BankManagementResource> stringLocalizer, TransactionManager transactionManager)
    {
        _accountRepository = accountRepository;
        _cardRepository = cardRepository;
        _transactionRepository = transactionRepository;
        _stringLocalizer = stringLocalizer;
        _transactionManager = transactionManager;
    }

    public async Task<TransactionDto> CreateAsync(TransactionCreateDto transactionCreateDto,
        CancellationToken cancellationToken = default)
    {
        var transaction = _transactionManager.Create(
            transactionCreateDto.SenderIban, 
            transactionCreateDto.RecevierIban,
            transactionCreateDto.Balance, 
            transactionCreateDto.TransactionTypeId
        );

        await _transactionRepository.InsertAsync(transaction, cancellationToken: cancellationToken);
        return ObjectMapper.Map<Transaction, TransactionDto>(transaction);
    }
    
    public async Task<List<TransactionDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var transactions = await _transactionRepository.GetListAsync(true, cancellationToken);
        return ObjectMapper.Map<List<Transaction>, List<TransactionDto>>(transactions);
        
        /*return (await _transactionRepository.GetListAsync(true, cancellationToken)).Select(x => new TransactionDto()
        {
            SenderIban = x.SenderIban,
            RecevierIban = x.ReceiverIban,
            Balance = x.Balance,
            TransactionTypeId = x.TransactionTypeId
        }).ToList();*/
    }

    public async Task<TransactionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transaction = await _transactionRepository.GetAsync(x => x.Id.Equals(id), cancellationToken: cancellationToken);

        if (transaction == null)
        {
            throw new UserFriendlyException(_stringLocalizer[TransactionExceptionCodes.NotFound]);
        }

        return ObjectMapper.Map<Transaction, TransactionDto>(transaction);
    }
}