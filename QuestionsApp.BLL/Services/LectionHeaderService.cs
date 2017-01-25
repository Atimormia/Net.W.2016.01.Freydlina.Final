using System;
using System.Collections.Generic;
using System.Linq;
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
    public class LectionHeaderService: ILectionHeaderService
    {
        private IUnitOfWork unitOfWork;
        private ILectionHeaderRepository lectionHeaderRepository; 

        public LectionHeaderService(IUnitOfWork unitOfWork, ILectionHeaderRepository lectionHeaderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.lectionHeaderRepository = lectionHeaderRepository;
        }
        
        public void Create(LectionHeaderEntity lectionHeader)
        {
            lectionHeaderRepository.Add(Mapper.Map<LectionHeaderEntity,DalLectionHeader>(lectionHeader));
            unitOfWork.Commit();
        }

        public LectionHeaderEntity GetById(int id)
        {
            return Mapper.Map<DalLectionHeader,LectionHeaderEntity>(lectionHeaderRepository.GetById(id));
        }

        public void Update(LectionHeaderEntity header)
        {
            lectionHeaderRepository.Update(Mapper.Map<LectionHeaderEntity,DalLectionHeader>(header));
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            lectionHeaderRepository.Delete(h => h.Id == id);
            unitOfWork.Commit();
        }

        public IEnumerable<LectionHeaderEntity> Search(string searchText)
        {
            return
                lectionHeaderRepository.GetMany(h => h.LectionTitle.Contains(searchText))
                    .Select(Mapper.Map<DalLectionHeader, LectionHeaderEntity>).ToList();
        }

        public IEnumerable<LectionHeaderEntity> GetUserHeaders(int userProfileId)
        {
            var dals = lectionHeaderRepository.GetMany(h => h.UserProfileId == userProfileId).ToList();
            var result = dals.Select(Mapper.Map<DalLectionHeader, LectionHeaderEntity>).ToList();
            return result;
        }
    }
}
