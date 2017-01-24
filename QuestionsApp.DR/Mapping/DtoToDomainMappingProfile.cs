﻿using AutoMapper;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DR.Mapping
{

    public class DtoToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DtoToDomainMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<DalAppUser, ApplicationUser>();//.ForMember(x => x.Id, opt => opt.Ignore());
            Mapper.CreateMap<DalAppUserRole,ApplicationRole>();
            Mapper.CreateMap<DalUserProfile, UserProfile>().ForMember(x=>x.UserId,opt=>opt.MapFrom(s=>s.AppUserId));
            Mapper.CreateMap<DalUserContact, UserContact>();
            Mapper.CreateMap<DalReportType, ReportType>();
            Mapper.CreateMap<DalReport, Report>();
            Mapper.CreateMap<DalQuestion, Question>();
            Mapper.CreateMap<DalLectionStatus, LectionStatus>();
            Mapper.CreateMap<DalLectionHeader, LectionHeader>();
            Mapper.CreateMap<DalLectionEvent, LectionEvent>();
            //Mapper.CreateMap<XViewModel, X()
            //    .ForMember(x => x.PropertyXYZ, opt => opt.MapFrom(source => source.Property1));     
        }
    }
}