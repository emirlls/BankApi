using System;
using BankManagement.Entities;
using BankManagement.ExceptionCodes;
using BankManagement.Extensions;
using BankManagement.Localization;
using BankManagement.Models.BranchMapFeatures;
using BankManagement.Repositories;
using Microsoft.Extensions.Localization;

namespace BankManagement.Managers;

public class BranchMapFeatureManager : ExtendedManager<BranchMapFeature, IBranchMapFeatureRepository>
{
    public BranchMapFeatureManager(IBranchMapFeatureRepository repository,
        IStringLocalizer<BankManagementResource> stringLocalizer) : base(repository, stringLocalizer,
        BranchMapFeatureExceptionCodes.NotFound)
    {
    }

    public BranchMapFeature Create(BranchMapFeatureCreateModel branchMapFeatureCreateModel)
    {
        return new BranchMapFeature(GuidGenerator.Create(), DateTime.Now)
        {
            BranchId = branchMapFeatureCreateModel.BranchId,
            Geom = branchMapFeatureCreateModel.GeoJson.ConvertGeoJsonToGeometry()
        };
    }

    public BranchMapFeature Update(
        BranchMapFeature branchMapFeature,
        BranchMapFeatureUpdateModel branchMapFeatureUpdateModel
    )
    {
        branchMapFeature.BranchId = branchMapFeatureUpdateModel.BranchId;
        branchMapFeature.Geom = branchMapFeatureUpdateModel.GeoJson.ConvertGeoJsonToGeometry();
        return branchMapFeature;
    }
}