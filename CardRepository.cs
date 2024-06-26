using BankModule.Entities;
using BankModule.EntityFrameworkCore;
using BankModule.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace BankModule.Repositories
{
    public class CardRepository : EfCoreRepository<BankModuleDbContext, Cards, Guid>, ICardRepository
    {

        public CardRepository(IDbContextProvider<BankModuleDbContext> contextProvider) : base(contextProvider) { }

        public async Task<Guid> GetCardId(string cardNumber)
        {

            return DbContext.Cards.FirstOrDefault(c=>c.card_number == cardNumber).Id;
        }

        public async Task<Cards> GetByCardNumberAsync(string cardNumber)
        {
            return await DbContext.Cards.FirstOrDefaultAsync(c => c.card_number == cardNumber);
        }


        public async Task<Cards> AddCardAsync(Cards cards)
        {
            if (cards==null) throw new ArgumentNullException(nameof(cards));


            DbContext.Cards.Add(cards);
            await DbContext.SaveChangesAsync();
            return cards;
        }

        public async Task<Cards> UpdateCardStatusAsync(string cardNumber, bool is_active)
        {
            var result = DbContext.Cards.FirstOrDefault(c => c.card_number == cardNumber);
            result.is_active = is_active;
            await DbContext.SaveChangesAsync();
            return result;
        }

        public async Task<Cards> checkCardNumber(string card_Number)
        {
            var result = DbContext.Cards.FirstOrDefault(c => c.card_number == card_Number);
            return result;
        }

        public async Task<bool> checkCardActive(string card_Number)
        {
            var result = DbContext.Cards.FirstOrDefault(c => c.card_number == card_Number);
            return result.is_active;

        }
    }
}
