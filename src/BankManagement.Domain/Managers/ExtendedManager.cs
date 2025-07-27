using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BankManagement.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace BankManagement.Managers;

public abstract class ExtendedManager<TEntity,TRepository> : DomainService
where TEntity : class, IEntity
where TRepository: IRepository<TEntity>
{
    private readonly TRepository _repository;
    private readonly IStringLocalizer<BankManagementResource> _stringLocalizer;
    private readonly string _notFoundExceptionMessage;
    protected ExtendedManager(TRepository repository,IStringLocalizer<BankManagementResource> stringLocalizer, string notFoundExceptinMessage)
    {
        _stringLocalizer = stringLocalizer;
        _notFoundExceptionMessage = notFoundExceptinMessage;
        _repository = repository;
    }

    public async Task<TEntity?> TryGetByAsync(Expression<Func<TEntity, bool>> predicate, bool throwIfNotExists = false)
    {
        var response = await _repository.FirstOrDefaultAsync(predicate);
        if (response == null && throwIfNotExists)
        {
            var message = string.Format(
                _stringLocalizer[_notFoundExceptionMessage]);
            throw new UserFriendlyException(message);
        }
        return response;
    }
}