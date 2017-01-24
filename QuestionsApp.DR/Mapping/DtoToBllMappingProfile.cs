using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.DAL.Interface.DTO;

namespace QuestionsApp.DR.Mapping
{

    public class DtoToBllMappingProfile : Profile
    {
        public override string ProfileName => "DtoToBllMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<DalAppUser, AppUserEntity>();
            Mapper.CreateMap<DalAppUserRole,AppUserRoleEntity>();
            Mapper.CreateMap<DalUserProfile, UserProfileEntity>();
            Mapper.CreateMap<DalUserContact, UserContactEntity>();
            Mapper.CreateMap<DalReportType, ReportTypeEntity>();
            Mapper.CreateMap<DalReport, ReportEntity>();
            Mapper.CreateMap<DalQuestion, QuestionEntity>();
            Mapper.CreateMap<DalLectionStatus, LectionStatusEntity>();
            Mapper.CreateMap<DalLectionHeader, LectionHeaderEntity>();
            Mapper.CreateMap<DalLectionEvent, LectionEventEntity>();
            //Mapper.CreateMap<XViewModel, X()
            //    .ForMember(x => x.PropertyXYZ, opt => opt.MapFrom(source => source.Property1));     
        }
    }
}