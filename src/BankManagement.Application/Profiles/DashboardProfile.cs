using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BankManagement.Constants;
using BankManagement.Dtos.Dashboards;
using BankManagement.Enums;
using BankManagement.Extensions;
using BankManagement.Models.Dashboards;
using Volo.Abp.AutoMapper;

namespace BankManagement.Profiles;

public class DashboardProfile: Profile
{
    public DashboardProfile()
    {
        CreateMap<DailyTransactionCountModel, DashboardDto>()
            .ForMember(x => x.LastUpdateTime, a =>
                a.MapFrom(x => DateTime.Now))
            .Ignore(x=>x.Labels)
            .Ignore(x=>x.DataSets)
            .AfterMap<DailyTransactionCountMappingAction>();
    }
    
    public class DailyTransactionCountMappingAction : IMappingAction<DailyTransactionCountModel, DashboardDto>
    {
        public void Process(DailyTransactionCountModel source, DashboardDto destination, ResolutionContext context)
        {
            destination.Labels = source.Days;
            destination.DataSets = new List<DashboardDataSetDto>
            {
                new DashboardDataSetDto
                {
                    Label = DashboardLabels.DailyTransactionCount.GetDescription(),
                    BackgroundColor = DashboardConstants.BackgroundColors.DailyLoginColor,
                    Data = source.Count.Cast<object>().ToList()
                }
            };
        }
    }
}