using BankModule.DTOs;
using BankModule.Entities;
using BankModule.RepositoryInterfaces;
using BankModule.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace BankModule.Services
{
    public class AccountService:ApplicationService,IAccountService


    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository) {

            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }


        public async Task<Account> AddCustomerAccount(CustomerDTO customerDTO)
        {

            var customer = new Customer
            {
                full_name=customerDTO.full_name,
                identity_number=customerDTO.identity_number,
                birth_place=customerDTO.birth_place,
                birth_date=customerDTO.BirthDate,
                risk_limit=customerDTO.risk_limit,
            };

            var account = new Account
            {
                account_name = customerDTO.account_name,
                account_number = customerDTO.account_number,
                iban = customerDTO.iban,
                is_active = customerDTO.is_active,
                balance = 0,
                Customer = customer,
            };

            if (account == null) throw new ArgumentNullException(nameof(account));

            await _accountRepository.AddCustomerAccount(account, customer);
            return account;
        }



        public async Task<string> UpdateCustomerAccount(string account_Number, bool isActive)
        {
            if (await _accountRepository.checkAccountNumber(account_Number) != null)
            {
                await _accountRepository.UpdateAccountActivity(account_Number, isActive);
                return "Hesap aktivitesi güncellendi.";
            }
            return "Numarayla eşleşen hesap bulunamadı.";
        }

       
    }
}
