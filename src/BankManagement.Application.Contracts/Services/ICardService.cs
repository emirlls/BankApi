using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Cards;
using Volo.Abp.Application.Services;

namespace BankManagement.Services;

public interface ICardService:IApplicationService
{
    public Task<bool> CreateAsync(CardCreateDto cardCreateDto, CancellationToken cancellationToken = default);

    public Task<bool> UpdateAsync(Guid id, CardUpdateDto cardUpdateDto,
        CancellationToken cancellationToken = default);

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    public Task<CardCommonDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    public Task<List<CardCommonDto>> GetListAsync(CancellationToken cancellationToken = default);

}