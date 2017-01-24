using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.WebUI.ViewModels;

namespace QuestionsApp.WebUI.Mapping
{

    public class ViewModelToEntityMappingProfile : Profile
    {
        public override string ProfileName => "ViewModelToEntityMappings";

        protected override void Configure()
        {
            //Mapper.CreateMap<UserForm, ApplicationUser>();
            Mapper.CreateMap<UserProfileViewModel, UserProfileEntity>()
                .ForMember(x=>x.AppUserId,opt=>opt.MapFrom(s=>s.UserId))
                .ForMember(x=>x.Id,opt=>opt.MapFrom(s=>s.UserProfileId));
           // Mapper.CreateMap<UserContactForm,UserContact>();
            //Mapper.CreateMap<ReportTypeForm,ReportType>();
            //Mapper.CreateMap<ReportForm,Report>();
            Mapper.CreateMap<QuestionViewModel, QuestionEntity>();
            //Mapper.CreateMap<LectionStatusForm,LectionStatus>();
            Mapper.CreateMap<LectionHeaderViewModel, LectionHeaderEntity>();
            Mapper.CreateMap<LectionEventViewModel, LectionEventEntity>();
            //Mapper.CreateMap<XViewModel, X()
            //    .ForMember(x => x.PropertyXYZ, opt => opt.MapFrom(source => source.Property1));     
        }
    }
}