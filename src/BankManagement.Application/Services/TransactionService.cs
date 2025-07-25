using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Constants;
using BankManagement.DistributedEvents.Transactions;
using BankManagement.Dtos;
using BankManagement.Dtos.Transactions;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Managers;
using BankManagement.Models.ElasticSearchs;
using BankManagement.Models.Transactions;
using BankManagement.Repositories;
using BankManagement.Repositories.ElasticSearchs;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.EventBus.Distributed;

namespace BankManagement.Services;

public class TransactionService : ApplicationService, ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;
    private readonly TransactionManager _transactionManager;
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;
    private readonly IDistributedEventBus _distributedEventBus;
    private readonly IEsTransactionRepository _esTransactionRepository;

    public TransactionService(
        ITransactionRepository transactionRepository, IStringLocalizer<BankManagementResource> stringLocalizer,
        TransactionManager transactionManager, IDistributedEventBus distributedEventBus,
        IEsTransactionRepository esTransactionRepository)
    {
        _transactionRepository = transactionRepository;
        _stringLocalizer = stringLocalizer;
        _transactionManager = transactionManager;
        _distributedEventBus = distributedEventBus;
        _esTransactionRepository = esTransactionRepository;
    }

    public async Task<bool> CreateAsync(TransactionCreateDto transactionCreateDto,
        CancellationToken cancellationToken = default)
    {
        var transactionCreateModel =
            ObjectMapper.Map<TransactionCreateDto, TransactionCreateModel>(transactionCreateDto);
        var transaction = _transactionManager.Create(transactionCreateModel);
        await _transactionRepository.InsertAsync(transaction, cancellationToken: cancellationToken);
        await _distributedEventBus.PublishAsync(new TransactionCreateEto
        {
            Transaction = transaction
        });
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, TransactionUpdateDto transactionUpdateDto,
        CancellationToken cancellationToken = default)
    {
        var transaction = await _transactionManager.TryGetByAsync(x => x.Id.Equals(id), true);
        var transactionUpdateModel =
            ObjectMapper.Map<TransactionUpdateDto, TransactionUpdateModel>(transactionUpdateDto);
        var updatedTransaction = _transactionManager.Update(transaction, transactionUpdateModel);
        await _transactionRepository.UpdateAsync(updatedTransaction, cancellationToken: cancellationToken);
        await _distributedEventBus.PublishAsync(new TransactionUpdateEto
        {
            Transaction = updatedTransaction
        });
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transaction =
            await _esTransactionRepository.GetDocumentAsync(id, ElasticSearchConstants.Transaction.TransactionIndex,
                cancellationToken);
        if (transaction == null)
        {
            throw new UserFriendlyException(_stringLocalizer[TransactionExceptionCodes.NotFound]);
        }

        await _distributedEventBus.PublishAsync(new TransactionDeleteEto
        {
            Id = transaction.Id
        });
        return true;
    }

    public async Task<List<TransactionDto>> GetListAsync(CancellationToken cancellationToken = default)
    {
        var transactionElasticModel =
            (await _esTransactionRepository.SearchAsync(ElasticSearchConstants.Transaction.TransactionIndex,
                cancellationToken: cancellationToken))
            .ToList();
        var response = ObjectMapper.Map<List<TransactionElasticModel>, List<TransactionDto>>
            (transactionElasticModel);
        return response;
    }

    public async Task<TransactionDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var transaction =
            await _esTransactionRepository.GetDocumentAsync(id, ElasticSearchConstants.Transaction.TransactionIndex,
                cancellationToken);

        if (transaction == null)
        {
            throw new UserFriendlyException(_stringLocalizer[TransactionExceptionCodes.NotFound]);
        }

        return ObjectMapper.Map<TransactionElasticModel, TransactionDto>(transaction);
    }
}