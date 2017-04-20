using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.WebUI.ViewModels;

namespace QuestionsApp.WebUI.Mapping
{
    public class EntityToViewModelMappingProfile : Profile
    {
        public override string ProfileName => "EntityToViewModelMappings";

        protected override void Configure()
        {
            Mapper.CreateMap<LectionEventEntity, LectionEventViewModel>();
            Mapper.CreateMap<LectionStatusEntity, LectionStatusViewModel>();
            Mapper.CreateMap<LectionHeaderEntity, LectionHeaderViewModel>();
            Mapper.CreateMap<QuestionEntity, QuestionViewModel>()
                .ForMember(x => x.IdForClient, opt => opt.MapFrom(s => s.IdOnClient));
            //Mapper.CreateMap<Report, ReportViewModel>();
            //Mapper.CreateMap<ReportType, ReportTypeViewModel>();
            Mapper.CreateMap<UserContactEntity, UserContactViewModel>();
            Mapper.CreateMap<UserProfileEntity, UserProfileViewModel>()
                .ForMember(x => x.UserProfileId, opt => opt.MapFrom(s => s.Id));
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