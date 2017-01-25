using QuestionsApp.DAL.Infrastructure;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Repository;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DAL.Concrete
{
    public class LectionStatusRepository : RepositoryBase<DalLectionStatus, LectionStatus>, ILectionStatusRepository
    {
        public LectionStatusRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
