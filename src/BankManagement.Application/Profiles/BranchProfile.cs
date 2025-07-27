using System.Linq;
using AutoMapper;
using BankManagement.Dtos.Branches;
using BankManagement.Entities;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Models.Branches;
using BankManagement.Models.BranchMapFeatures;
using Volo.Abp.AutoMapper;

namespace BankManagement.Profiles;

public class BranchProfile : Profile
{
    public BranchProfile()
    {
        CreateMap<Branch, BranchDto>()
            .ForMember(x => x.BranchTypeName, a =>
                a.MapFrom(x => ((BranchTypes)x.BranchType.Code).GetDescription()))
            .ForMember(x => x.GeoJson, a =>
                a.MapFrom(x =>
                    x.BranchMapFeatures.FirstOrDefault()!.Geom.ConvertGeomToGeoJson().GetAwaiter().GetResult()));

        CreateMap<BranchCreateDto, BranchCreateModel>();
        CreateMap<BranchCreateDto, BranchMapFeatureCreateModel>()
            .Ignore(x => x.BranchId);
        CreateMap<BranchUpdateDto, BranchUpdateModel>();
        CreateMap<BranchUpdateDto, BranchMapFeatureUpdateModel>()
            .Ignore(x => x.BranchId);
        CreateMap<BranchUpdateDto, BranchMapFeatureCreateModel>()
            .Ignore(x => x.BranchId);
    }
}