using BankManagement.Dtos;
using BankManagement.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BankManagement.Validators;

public class TransactionCreateDtoValidator:AbstractValidator<TransactionCreateDto>
{
    public TransactionCreateDtoValidator(IStringLocalizer<BankManagementResource> stringLocalizer)
    {
        RuleFor(x => x.SenderIban)
            .NotEmpty();
        RuleFor(x => x.ReceiverIban)
            .NotEmpty();
        RuleFor(x => x.Balance)
            .NotEmpty();
        RuleFor(x => x.TransactionTypeId)
            .NotEmpty();
    }
}