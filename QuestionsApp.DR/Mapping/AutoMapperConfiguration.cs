using AutoMapper;

namespace QuestionsApp.DR.Mapping
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BllToDtoMappingProfile>();
                x.AddProfile<DtoToBllMappingProfile>();
                x.AddProfile<DomainToDtoMappingProfile>();
                x.AddProfile<DtoToDomainMappingProfile>();
            });
        }
    }
}