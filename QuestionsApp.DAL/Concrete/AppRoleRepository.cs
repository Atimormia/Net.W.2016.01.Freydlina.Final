using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity;
using QuestionsApp.DAL.Infrastructure;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Repository;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DAL.Concrete
{
    public class AppRoleRepository: RepositoryBase<DalAppUserRole,ApplicationRole>,IAppRoleRepository
    {
        private RoleManager<ApplicationRole> roleManager;

        public AppRoleRepository(IDatabaseFactory databaseFactory, RoleManager<ApplicationRole> roleManager) : base(databaseFactory)
        { 
            this.roleManager = roleManager;
        }

        public async Task<DalAppUserRole> FindByNameAsync(string roleName)
        {
            ApplicationRole role = await roleManager.FindByNameAsync(roleName);
            return Mapper.Map<ApplicationRole, DalAppUserRole>(role);
        }

        public async Task CreateAsync(DalAppUserRole role)
        {
            await roleManager.CreateAsync(Mapper.Map<DalAppUserRole, ApplicationRole>(role));
        }

        public void Dispose()
        {
            if (roleManager != null)
            {
                roleManager.Dispose();
                roleManager = null;
            }
        }
    }
}
