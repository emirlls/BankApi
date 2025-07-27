using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BankManagement.Dtos.Branches;
using BankManagement.Entities;
using BankManagement.Managers;
using BankManagement.Models.Branches;
using BankManagement.Models.BranchMapFeatures;
using BankManagement.Repositories;

namespace BankManagement.Services;

public class BranchService : BankManagementAppService, IBranchService
{
    private readonly IBranchRepository _branchRepository;
    private readonly BranchManager _branchManager;
    private readonly BranchMapFeatureManager _branchMapFeatureManager;
    private readonly IBranchMapFeatureRepository _branchMapFeatureRepository;

    public BranchService(IBranchRepository branchRepository, BranchManager branchManager,
        BranchMapFeatureManager branchMapFeatureManager, IBranchMapFeatureRepository branchMapFeatureRepository)
    {
        _branchRepository = branchRepository;
        _branchManager = branchManager;
        _branchMapFeatureManager = branchMapFeatureManager;
        _branchMapFeatureRepository = branchMapFeatureRepository;
    }

    public async Task<List<BranchDto>> GetListAllAsync(CancellationToken cancellationToken)
    {
        var branches = await _branchRepository.GetListAllAsync(cancellationToken);
        var response = ObjectMapper.Map<List<Branch>, List<BranchDto>>(branches);
        return response;
    }

    public async Task<bool> CreateAsync(BranchCreateDto branchCreateDto, CancellationToken cancellationToken)
    {
        var branchCreateModel = ObjectMapper.Map<BranchCreateDto, BranchCreateModel>(branchCreateDto);
        var branchMapFeatureCreateModel =
            ObjectMapper.Map<BranchCreateDto, BranchMapFeatureCreateModel>(branchCreateDto);
        var branch = _branchManager.Create(branchCreateModel);
        if (!string.IsNullOrWhiteSpace(branchCreateDto.GeoJson))
        {
            branchMapFeatureCreateModel.BranchId = branch.Id;
            var branchMapFeature = _branchMapFeatureManager.Create(branchMapFeatureCreateModel);
            await _branchMapFeatureRepository.InsertAsync(branchMapFeature, cancellationToken: cancellationToken);
        }
        await _branchRepository.InsertAsync(branch, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(Guid id, BranchUpdateDto branchUpdateDto, CancellationToken cancellationToken)
    {
        var branch = await _branchManager.TryGetByAsync(x => x.Id.Equals(id), throwIfNotExists: true);
        var branchUpdateModel = ObjectMapper.Map<BranchUpdateDto, BranchUpdateModel>(branchUpdateDto);
        var branchMapFeature =await _branchMapFeatureManager.TryGetByAsync(x => x.BranchId.Equals(branch.Id));
        if (branchMapFeature != null)
        {
            await _branchMapFeatureRepository.DeleteAsync(branchMapFeature, cancellationToken: cancellationToken);
        }
        if (!string.IsNullOrWhiteSpace(branchUpdateDto.GeoJson))
        {
            var branchMapFeatureCreateModel = ObjectMapper.Map<BranchUpdateDto, BranchMapFeatureCreateModel>(branchUpdateDto);
            branchMapFeatureCreateModel.BranchId = branch!.Id;
            var updatedBranchMapFeature = _branchMapFeatureManager.Create(branchMapFeatureCreateModel);
            await _branchMapFeatureRepository.UpdateAsync(updatedBranchMapFeature, cancellationToken: cancellationToken);
        }

        var updatedBranch = _branchManager.Update(branch!, branchUpdateModel);
        await _branchRepository.UpdateAsync(updatedBranch, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var branch = await _branchManager.TryGetByAsync(x => x.Id.Equals(id), throwIfNotExists: true);
        var branchMapFeature =await _branchMapFeatureManager.TryGetByAsync(x => x.BranchId.Equals(branch!.Id));
        if (branchMapFeature != null)
        {
            await _branchMapFeatureRepository.DeleteAsync(branchMapFeature, cancellationToken: cancellationToken);
        }

        await _branchRepository.DeleteAsync(branch!, cancellationToken: cancellationToken);
        return true;
    }
}