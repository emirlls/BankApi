using BankModule.DTOs;
using BankModule.RepositoryInterfaces;
using BankModule.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using BankModule.Entities;
using AutoMapper;

namespace BankModule.Services
{
    public class CardService:ApplicationService,ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IAccountRepository _accountRepository;


        public CardService(ICardRepository cardRepository, IAccountRepository accountRepository)
        {
            _cardRepository = cardRepository; _accountRepository = accountRepository;
        }


        public async Task<string> AddCardAsync(CardDTO cardDTO)
        {

            if (await _accountRepository.checkAccountNumber(cardDTO.account_number) != null)
            {
                try
                {
                    Guid id = await _accountRepository.GetAccountId(cardDTO.account_number);


                    var card = new Cards
                    {
                        AccountId = id,
                        card_number = cardDTO.card_number,
                        card_type = cardDTO.card_type,
                        expiration_month = cardDTO.expiration_month,
                        expiration_year = cardDTO.expiration_year,
                        ccv = cardDTO.ccv,
                        credit_limit = cardDTO.credit_limit,
                        is_active = cardDTO.is_active

                    };

                    await _cardRepository.AddCardAsync(card);
                    return "Kart başarıyla oluşturuldu.";

                }

                catch (Exception ex) { throw new Exception(nameof(CardService), ex); }

            }
            return "Numarayla eşleşen hesap bulunamadı";
        }

        public async Task<string> UpdateCardActivityAsync(string cardNumber, bool is_active)
        {
            if (await _cardRepository.checkCardNumber(cardNumber) != null)
            {
                await _cardRepository.UpdateCardStatusAsync(cardNumber, is_active);
                return "Kart aktivitesi güncellendi.";
            }
            return "Kart aktivitesi güncellenemedi.";

        }

    }
}
