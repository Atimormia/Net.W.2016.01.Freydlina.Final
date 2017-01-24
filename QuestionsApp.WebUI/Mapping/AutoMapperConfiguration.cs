using AutoMapper;
using QuestionsApp.DR.Mapping;

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
                x.AddProfile<BllToDtoMappingProfile>();
                x.AddProfile<DtoToBllMappingProfile>();
                x.AddProfile<DomainToDtoMappingProfile>();
                x.AddProfile<DtoToDomainMappingProfile>();
            });
        }
    }
}