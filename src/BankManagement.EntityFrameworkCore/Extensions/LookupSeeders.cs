using System;
using BankManagement.Constants;
using BankManagement.Entities.LookUps;
using Microsoft.EntityFrameworkCore;

namespace BankManagement.Extensions;

public static class LookupSeeders
{
    public static void LookupSeeder(this ModelBuilder builder)
    {
        #region AccountTypes
        builder.Entity<AccountType>().HasData(
            new AccountType(Guid.Parse(LookupSeederConstants.AccountTypes.Deposite),null,DateTime.Now)
            {
                Code = 1,
                Name = "Deposite"
            },
            new AccountType(Guid.Parse(LookupSeederConstants.AccountTypes.Checking),null,DateTime.Now)
            {
                Code = 2,
                Name = "Checking"
            }
        );
        #endregion
        
        #region CardTypes
        builder.Entity<CardType>().HasData(
            new CardType(Guid.Parse(LookupSeederConstants.CardTypes.Bank),null,DateTime.Now)
            {
                Code = 1,
                Name = "Bank"
            },
            new CardType(Guid.Parse(LookupSeederConstants.CardTypes.Credit),null,DateTime.Now)
            {
                Code = 2,
                Name = "Credit"
            }
        );
        #endregion
        
        #region TransactionTypes
        builder.Entity<TransactionType>().HasData(
            new TransactionType(Guid.Parse(LookupSeederConstants.TransactionTypes.ToAccount),null,DateTime.Now)
            {
                Code = 1,
                Name = "ToAccount"
            },
            new TransactionType(Guid.Parse(LookupSeederConstants.TransactionTypes.ToCard),null,DateTime.Now)
            {
                Code = 2,
                Name = "ToCard"
            }
        );
        #endregion

        #region BranchTypes
        builder.Entity<BranchType>().HasData(
            new BranchType(Guid.Parse(LookupSeederConstants.BranchTypes.Branch),null,DateTime.Now)
            {
                Code = 1,
                Name = "Branch"
            },
            new BranchType(Guid.Parse(LookupSeederConstants.BranchTypes.Atm),null,DateTime.Now)
            {
                Code = 2,
                Name = "Atm"
            }
        );
        #endregion
    }
}