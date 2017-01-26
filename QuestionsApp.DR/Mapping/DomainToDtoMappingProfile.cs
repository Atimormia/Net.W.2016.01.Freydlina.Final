using AutoMapper;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DR.Mapping
{
    public class DomainToDtoMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDtoMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ApplicationUser,DalAppUser>();
            Mapper.CreateMap<ApplicationRole,DalAppUserRole>();
            Mapper.CreateMap<LectionStatus, DalLectionStatus>();
            Mapper.CreateMap<LectionHeader, DalLectionHeader>();
            Mapper.CreateMap<LectionEvent, DalLectionEvent>();
                //.ForMember(x => x.LectionStatus,
                //    opt => opt.MapFrom(s => Mapper.Map<LectionStatus, DalLectionStatus>(s.LectionStatus)))
                //.ForMember(x => x.LectionHeader,
                //    opt => opt.MapFrom(s => Mapper.Map<LectionHeader, DalLectionHeader>(s.LectionHeader)));
            Mapper.CreateMap<Question, DalQuestion>();
            Mapper.CreateMap<Report, DalReport>();
            Mapper.CreateMap<ReportType, DalReportType>();
            Mapper.CreateMap<UserContact, DalUserContact>();
            Mapper.CreateMap<UserProfile, DalUserProfile>()
                .ForMember(x => x.Id, opt => opt.MapFrom(s => s.UserProfileId));
        }
    }
}