using QuestionsApp.DAL.Infrastructure;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.DAL.Interface.Repository;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DAL.Concrete
{
    public class UserProfileRepository:RepositoryBase<DalUserProfile,UserProfile>,IUserProfileRepository
    {
        public UserProfileRepository(IDatabaseFactory databaseFactory): base(databaseFactory) { }
    }
}
