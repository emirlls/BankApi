using BankModule.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BankModule.RepositoryInterfaces
{
    public interface ICardRepository:IRepository<Cards,Guid>
    {
        Task<Cards> GetByCardNumberAsync(string cardNumber);

        Task<Cards> AddCardAsync(Cards cards);

        Task<Guid> GetCardId(string cardNumber);

        Task <Cards> UpdateCardStatusAsync(string cardNumber, bool is_active);

        Task<Cards> checkCardNumber(string card_Number);

        Task<bool> checkCardActive(string card_Number);
    }
}
