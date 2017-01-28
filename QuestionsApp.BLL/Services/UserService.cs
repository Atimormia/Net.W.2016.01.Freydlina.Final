using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.DAL.Interface.Repository;

namespace QuestionsApp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork uow;
        private readonly IAppUserRepository userRepository;
        private readonly IAppRoleRepository roleRepository;
        private readonly IUserProfileRepository userProfileRepository;

        public UserService(IUnitOfWork uow, IAppUserRepository repository,
            IAppRoleRepository roleRepository, IUserProfileRepository userProfileRepository)
        {
            this.uow = uow;
            this.userRepository = repository;
            this.roleRepository = roleRepository;
            this.userProfileRepository = userProfileRepository;
        }

        public AppUserEntity GetUserEntity(int id)
        {
            return Mapper.Map<DalAppUser,AppUserEntity>(userRepository.GetById(id));
        }

        public IEnumerable<AppUserEntity> GetAllUserEntities()
        {
            return userRepository.GetAll().Select(Mapper.Map<DalAppUser,AppUserEntity>);
        }

        //public void CreateUser(AppUserEntity userEntity)
        //{
        //    userRepository.Create(userEntity.ToDalUser());
        //    uow.Commit();
        //}

        public void DeleteUser(AppUserEntity user)
        {
            userRepository.Delete(Mapper.Map<AppUserEntity,DalAppUser>(user));
            uow.Commit();
        }

        public async Task<OperationDetails> Create(AppUserEntity userEntity)
        {
            DalAppUser user = await userRepository.FindByEmailAsync(userEntity.Email);
            if (user == null)
            {
                user = Mapper.Map<AppUserEntity,DalAppUser>(userEntity);
                var result = await userRepository.CreateAsync(user, userEntity.PasswordHash);
                var errorsList = result as IList<string> ?? result.ToList();
                if (errorsList.Any())
                    return new OperationDetails(false, errorsList.FirstOrDefault(), "");
                // добавляем роль
                await userRepository.AddToRoleAsync(user.Id, userEntity.Role);
                // создаем профиль клиента
                DalUserProfile userProfile = new DalUserProfile { UserId = user.Id };
                userProfileRepository.Add(userProfile);
                await uow.SaveAsync();
                return new OperationDetails(true, "Registering is success", "");
            }
            return new OperationDetails(false, "User with such name exists", "Email");
        }

        public async Task<ClaimsIdentity> Authenticate(AppUserEntity userEntity)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            DalAppUser user = await userRepository.FindAsync(userEntity.Email, userEntity.PasswordHash);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await userRepository.CreateIdentityAsync(user,"ApplicationCookie");
            await uow.SaveAsync();
            return claim;
        }

        public async Task SetInitialData(AppUserEntity adminEntity, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await roleRepository.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new DalAppUserRole { Name = roleName };
                    await roleRepository.CreateAsync(role);
                }
            }
            await Create(adminEntity);
            await uow.SaveAsync();
        }

        public async Task<ClaimsIdentity> CreateIdentityAsync(AppUserEntity user, string authenticationType)
        {
            var result = await userRepository.CreateIdentityAsync(Mapper.Map<AppUserEntity, DalAppUser>(user), authenticationType);
            await uow.SaveAsync();
            return result;
        }

        public async Task<AppUserEntity> FindAsync(string email, string password)
        {
            DalAppUser result = await userRepository.FindAsync(email, password);
            return Mapper.Map<DalAppUser, AppUserEntity>(result);
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string code)
        {
            var result = await userRepository.ConfirmEmailAsync(userId, code);
            await uow.SaveAsync();
            return result;
        }

        public async Task<AppUserEntity> FindByNameAsync(string email)
        {
            DalAppUser result = await userRepository.FindByEmailAsync(email);
            return Mapper.Map<DalAppUser, AppUserEntity>(result);
        }

        public async Task<bool> IsEmailConfirmedAsync(string id)
        {
            return await userRepository.IsEmailConfirmedAsync(id);
        }

        public async Task<IEnumerable<string>> ResetPasswordAsync(string id, string code, string password)
        {
            var result = await userRepository.ResetPasswordAsync(id, code, password);
            await uow.SaveAsync();
            return result;
        }

        public async Task<IEnumerable<string>> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
        {
            var result =
                await userRepository.ChangePasswordAsync(userId, oldPassword, newPassword);
            await uow.SaveAsync();
            return result;
        }

        public async Task<AppUserEntity> FindByIdAsync(string userId)
        {
            var result = await userRepository.FindByIdAsync(userId);
            return Mapper.Map<DalAppUser, AppUserEntity>(result);
        }
    }
}
