using AutoMapper;

namespace QuestionsApp.WebUI.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToViewModelMappingProfile>();
                x.AddProfile<ViewModelToEntityMappingProfile>();
            });
        }
    }
}