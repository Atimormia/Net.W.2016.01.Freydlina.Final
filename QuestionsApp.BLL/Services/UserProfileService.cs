using System;
using System.Collections.Generic;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.DAL.Interface.Repository;

namespace QuestionsApp.BLL.Services
{
    public class UserProfileService:IUserProfileService
    {
        private IUserProfileRepository userProfileRepository;
        private IUnitOfWork unitOfWork;

        public UserProfileService(IUnitOfWork unitOfWork, IUserProfileRepository userProfileRepository)
        {
            this.unitOfWork = unitOfWork;
            this.userProfileRepository = userProfileRepository;
        }

        public UserProfileEntity GetById(int id)
        {
            return Mapper.Map<DalUserProfile, UserProfileEntity>(userProfileRepository.GetById(id));
        }

        public UserProfileEntity GetByAppUserId(string userId)
        {
            return Mapper.Map<DalUserProfile, UserProfileEntity>(userProfileRepository.Get(x=>x.AppUserId == userId));
        }
        
        public void Update(UserProfileEntity user)
        {
            userProfileRepository.Update(Mapper.Map<UserProfileEntity,DalUserProfile>(user));
            unitOfWork.Commit();
        }
        
    }
}
