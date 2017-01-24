using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Repository;
using QuestionsApp.ORM.Model;
using AutoMapper;
using QuestionsApp.DAL.Infrastructure;

namespace QuestionsApp.DAL.Concrete
{
    public class AppUserRepository: RepositoryBase<DalAppUser,ApplicationUser> ,IAppUserRepository
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AppUserRepository(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IDatabaseFactory databaseFactory):base(databaseFactory)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        
        public async Task<DalAppUser> FindByEmailAsync(string email)
        {
            ApplicationUser user = await userManager.FindByEmailAsync(email);
            return Mapper.Map<ApplicationUser, DalAppUser>(user);
        }

        public async Task<IEnumerable<string>> CreateAsync(DalAppUser user, string password)
        {
            try
            {
                ApplicationUser userDomain = Mapper.Map<DalAppUser, ApplicationUser>(user);
                //    new ApplicationUser
                //{
                //    Email = user.Email,
                //    UserName = user.UserName
                //};
                var result = await userManager.CreateAsync(userDomain, password);
                return result.Errors;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }

        public async Task AddToRoleAsync(string userId, string role)
        {
            var roleEntity = await roleManager.FindByNameAsync(role);
            if (roleEntity == null)
                await roleManager.CreateAsync(new ApplicationRole {Id = Guid.NewGuid().ToString(), Name = role});
            await userManager.AddToRoleAsync(userId, role);
        }

        public async Task<DalAppUser> FindAsync(string userName, string password)
        {
            ApplicationUser user = await userManager.FindAsync(userName, password);
            return Mapper.Map<ApplicationUser, DalAppUser>(user);
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(DalAppUser user, string authenticationType)
        {
            ApplicationUser appUser = Mapper.Map<DalAppUser, ApplicationUser>(user);
            return await userManager.CreateIdentityAsync(appUser, authenticationType);
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {
            var result = await userManager.ConfirmEmailAsync(userId, code);
            return result.Succeeded;
        }

        public async Task<bool> IsEmailConfirmedAsync(string id)
        {
            return await userManager.IsEmailConfirmedAsync(id);
        }

        public async Task<IEnumerable<string>> ResetPasswordAsync(string id, string code, string password)
        {
            var result = await userManager.ResetPasswordAsync(id, code, password);
            return result.Errors;
        }

        public void Dispose()
        {
            if (userManager != null)
            {
                userManager.Dispose();
                userManager = null;
            }
            if (roleManager != null)
            {
                roleManager.Dispose();
                roleManager = null;
            }
        }
    }
}
