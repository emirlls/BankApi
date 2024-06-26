using BankModule.RepositoryInterfaces;
using BankModule.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using BankModule.Entities;
using Volo.Abp.Domain.Repositories;
using BankModule.DTOs;

namespace BankModule.Services
{
    public class TransactionService:ApplicationService,ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICardRepository _cardRepository;
        public TransactionService(ITransactionRepository transactionRepository, IAccountRepository accountRepository, ICardRepository cardRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _cardRepository = cardRepository;
        }

        public async Task<string> AddTransaction(TransactionDTO transactionDTO)
        {

            // Alıcı kartı bul
            var recipientCard = await _cardRepository.FirstOrDefaultAsync(c=>c.card_number == transactionDTO.RecipientCardNumber);
            if (recipientCard == null)
            {
                return "Alıcı kart bulunamadı.";
            }

            // Gönderici hesabı bul
            var senderAccount = await _accountRepository.FirstOrDefaultAsync(a => a.iban == transactionDTO.senderIban);
            if (senderAccount == null)
            {
                return "Gönderen hesap bulunamadı.";
            }

            // Gönderici hesabının bakiyesini kontrol et
            if (senderAccount.balance < transactionDTO.amount)
            {
                return "Hesap bakiyesi yetersiz";
            }

            // Gönderici hesabının bakiyesini güncelle
            senderAccount.balance -= transactionDTO.amount;

            // Alıcı hesabının bakiyesini güncelle
            recipientCard.credit_limit += transactionDTO.amount;

            // Transaction kaydı oluştur
            var transaction = new Transaction
            {
                amount = transactionDTO.amount,
                description = transactionDTO.description,
                transaction_date = DateTime.UtcNow,
                create_date = DateTime.UtcNow,
                transaction_type="Hesaptan karta transfer",
                AccountId = senderAccount.Id
            };
            await _transactionRepository.AddTransaction(transaction);
            
            return "Transfer işlemi yapıldı.";


        }
    }
}