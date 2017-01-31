using AutoMapper;
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
            Mapper.CreateMap<DalUserProfile, UserProfile>().ForMember(x=>x.UserProfileId,opt=>opt.MapFrom(s=>s.Id));
            Mapper.CreateMap<DalUserContact, UserContact>();
            Mapper.CreateMap<DalReportType, ReportType>();
            Mapper.CreateMap<DalReport, Report>();
            Mapper.CreateMap<DalQuestion, Question>()
                .ForMember(x => x.LectionEvent,
                    opt => opt.MapFrom(s => Mapper.Map<DalLectionEvent, LectionEvent>(s.LectionEvent)));
            Mapper.CreateMap<DalLectionStatus, LectionStatus>();
            Mapper.CreateMap<DalLectionHeader, LectionHeader>();
            Mapper.CreateMap<DalLectionEvent, LectionEvent>();
            //.ForMember(x => x.LectionHeader,
            //    opt => opt.MapFrom(s => Mapper.Map<DalLectionHeader, LectionHeader>(s.LectionHeader)))
            //.ForMember(x => x.LectionStatus,
            //    opt => opt.MapFrom(s => Mapper.Map<DalLectionStatus, LectionStatus>(s.LectionStatus))); 
        }
    }
}