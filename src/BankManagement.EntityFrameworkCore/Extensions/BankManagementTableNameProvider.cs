using System;
using BankManagement.Entities;
using BankManagement.Entities.LookUps;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankManagement.Extensions;

public static class BankManagementTableNameProvider
{
    public static string GetTableName<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : class => typeof(T).Name
        switch
        {
            nameof(Customer) => "Customers",
            nameof(Account) => "Accounts",
            nameof(Card) => "Cards",
            nameof(Transaction) => "Transactions",
            nameof(AccountType) => "AccountTypes",
            nameof(CardType) => "CardTypes",
            
            _ => throw new NotImplementedException()
        };
}