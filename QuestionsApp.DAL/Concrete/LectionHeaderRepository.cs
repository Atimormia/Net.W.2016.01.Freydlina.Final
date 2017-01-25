using QuestionsApp.DAL.Infrastructure;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Repository;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DAL.Concrete
{

    public class LectionHeaderRepository : RepositoryBase<DalLectionHeader, LectionHeader>, ILectionHeaderRepository
    {
        public LectionHeaderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
}
