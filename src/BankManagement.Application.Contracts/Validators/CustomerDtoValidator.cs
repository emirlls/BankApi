using BankManagement.Dtos;
using BankManagement.Dtos.Customers;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using FluentValidation;
using Microsoft.Extensions.Localization;

namespace BankManagement.Validators;

public class CustomerDtoValidator:AbstractValidator<CustomerDto>
{
    public CustomerDtoValidator(IStringLocalizer<BankManagementResource> stringLocalizer)
    {
        RuleFor(x => x.IdentityNumber)
            .NotEmpty()
            .WithMessage(stringLocalizer[CustomerExceptionCodes.IdentityNumber.CannotBeEmpty])
            .Length(11)
            .WithMessage(stringLocalizer[CustomerExceptionCodes.IdentityNumber.MaxLength]);
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage(stringLocalizer[CustomerExceptionCodes.Name.CannotBeEmpty]);
        
        RuleFor(x => x.Surname)
            .NotEmpty()
            .WithMessage(stringLocalizer[CustomerExceptionCodes.Surname.CannotBeEmpty]);

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage(stringLocalizer[CustomerExceptionCodes.Phone.CannotBeEmpty])
            .Length(10)
            .WithMessage(stringLocalizer[CustomerExceptionCodes.Phone.MaxLength]);
        
        RuleFor(x => x.Birthday)
            .NotEmpty()
            .WithMessage(stringLocalizer[CustomerExceptionCodes.BirthDay.CannotBeEmpty]);
        
    }
}