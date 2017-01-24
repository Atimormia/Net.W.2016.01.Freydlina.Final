using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.DAL.Interface.DTO;

namespace QuestionsApp.DR.Mapping
{
    public class BllToDtoMappingProfile : Profile
    {
        public override string ProfileName => "BllToDtoMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<AppUserEntity, DalAppUser>();
            Mapper.CreateMap<AppUserRoleEntity, DalAppUserRole>();
            Mapper.CreateMap<LectionEventEntity, DalLectionEvent>();
            Mapper.CreateMap<LectionStatusEntity, DalLectionStatus>();
            Mapper.CreateMap<LectionHeaderEntity, DalLectionHeader>();
            Mapper.CreateMap<QuestionEntity, DalQuestion>();
            Mapper.CreateMap<ReportEntity, DalReport>();
            Mapper.CreateMap<ReportTypeEntity, DalReportType>();
            Mapper.CreateMap<UserContactEntity, DalUserContact>();
            Mapper.CreateMap<UserProfileEntity, DalUserProfile>();
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