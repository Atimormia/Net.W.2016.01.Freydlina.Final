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
            Mapper.CreateMap<LectionEvent, DalLectionEvent>();
            Mapper.CreateMap<LectionStatus, DalLectionStatus>();
            Mapper.CreateMap<LectionHeader, DalLectionHeader>();
            Mapper.CreateMap<Question, DalQuestion>();
            Mapper.CreateMap<Report, DalReport>();
            Mapper.CreateMap<ReportType, DalReportType>();
            Mapper.CreateMap<UserContact, DalUserContact>();
            Mapper.CreateMap<UserProfile, DalUserProfile>();
            //Mapper.CreateMap<X, XViewModel>()
            //    .ForMember(x => x.Property1, opt => opt.MapFrom(source => source.PropertyXYZ));
            //Mapper.CreateMap<Goal, GoalListViewModel>().ForMember(x => x.SupportsCount, opt => opt.MapFrom(source => source.Supports.Count))
            //                                          .ForMember(x => x.UserName, opt => opt.MapFrom(source => source.User.UserName))
            //                                          .ForMember(x => x.StartDate, opt => opt.MapFrom(source => source.StartDate.ToString("dd MMM yyyy")))
            //                                          .ForMember(x => x.EndDate, opt => opt.MapFrom(source => source.EndDate.ToString("dd MMM yyyy")));
            //Mapper.CreateMap<Group, GroupsItemViewModel>().ForMember(x => x.CreatedDate, opt => opt.MapFrom(source => source.CreatedDate.ToString("dd MMM yyyy")));

            //Mapper.CreateMap<IPagedList<Group>, IPagedList<GroupsItemViewModel>>().ConvertUsing<PagedListConverter<Group, GroupsItemViewModel>>();


        }
    }
}