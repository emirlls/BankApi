using System;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Localization;
using BankManagement.Models.Branches;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Managers;

public class BranchManager : ExtendedManager<Branch, IBranchRepository>
{
    public BranchManager(IBranchRepository repository, IStringLocalizer<BankManagementResource> stringLocalizer) : base(
        repository, stringLocalizer, BranchExceptionCodes.NotFound)
    {
    }

    public Branch Create(BranchCreateModel branchCreateModel)
    {
        return new Branch(GuidGenerator.Create(), CurrentTenant.Id, DateTime.Now)
        {
            BranchTypeId = branchCreateModel.BranchTypeId,
            Name = branchCreateModel.Name
        };
    }

    public Branch Update(Branch branch, BranchUpdateModel branchUpdateModel)
    {
        branch.BranchTypeId = branchUpdateModel.BranchTypeId;
        branch.Name = branchUpdateModel.Name;
        return branch;
    }
}