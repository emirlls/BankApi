using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Branches;
using BankManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankManagement.Controllers;

//[Authorize]
[ApiController]
[Route("api/branches")]
public class BranchController : BankManagementController
{
    private readonly IBranchService _branchService;

    public BranchController(IBranchService branchService)
    {
        _branchService = branchService;
    }
    
    /// <summary>
    /// Used to get list of branches.It returns branch location, branch type and name.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet]
    public async Task<List<BranchDto>> GetListAllAsync(CancellationToken cancellationToken = default)
    {
        return await _branchService.GetListAllAsync(cancellationToken);
    }

    /// <summary>
    /// Used to create branch.Location, type and name are expected in dto
    /// </summary>
    /// <param name="branchCreateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<bool> CreateAsync(BranchCreateDto branchCreateDto, CancellationToken cancellationToken = default)
    {
        return await _branchService.CreateAsync(branchCreateDto, cancellationToken);
    }

    /// <summary>
    /// Used to update branch.Location, type and name are expected in dto.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="branchUpdateDto"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public async Task<bool> UpdateAsync(Guid id, BranchUpdateDto branchUpdateDto,
        CancellationToken cancellationToken = default)
    {
        return await _branchService.UpdateAsync(id, branchUpdateDto, cancellationToken);
    }

    /// <summary>
    /// Used to delete branch and its location.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _branchService.DeleteAsync(id, cancellationToken);
    }
}