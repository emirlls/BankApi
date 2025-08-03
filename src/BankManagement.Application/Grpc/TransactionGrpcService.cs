using System;
using System.Threading.Tasks;
using BankManagement.Dtos;
using BankManagement.Services;
using Grpc.Core;
namespace BankManagement.Grpc;

public class TransactionGrpcService: Transaction.TransactionBase
{
    private readonly ITransactionService _transactionService;

    public TransactionGrpcService(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }
    
    public override async Task<TransactionCreateResponse> Create(TransactionCreateRequest request, ServerCallContext context)
    {
        var result = await _transactionService.CreateAsync(new TransactionCreateDto
        {
            TransactionTypeId = Guid.Parse(request.TransactionTypeId),
            SenderIban = request.SenderIban,
            ReceiverIban = request.ReceiverIban,
            Balance = request.Balance
        });
        
        return new TransactionCreateResponse { Success = result };
    }
}