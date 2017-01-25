using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Repository;

namespace QuestionsApp.BLL.Services
{
    public class LectionStatusService: ILectionStatusService
    {
        private ILectionStatusRepository lectionStatusRepository;

        public LectionStatusService(ILectionStatusRepository lectionStatusRepository)
        {
            this.lectionStatusRepository = lectionStatusRepository;
        }

        public IEnumerable<LectionStatusEntity> GetAll()
        {
            return lectionStatusRepository.GetAll().Select(Mapper.Map<DalLectionStatus,LectionStatusEntity>);
        }

        public LectionStatusEntity GetByName(string name)
        {
            var lectionStatus = lectionStatusRepository.Get(u => u.StatusName == name);
            return Mapper.Map<DalLectionStatus,LectionStatusEntity>(lectionStatus);
        }
    }
}
