using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.DAL.Interface.Repository;
using System.Web.UI.WebControls;

namespace QuestionsApp.BLL.Services
{
    public class LectionEventService: ILectionEventService
    {
        private IUnitOfWork unitOfWork;
        private ILectionEventRepository lectionEventRepository;
        private ILectionHeaderRepository lectionHeaderRepository;

        public LectionEventService(IUnitOfWork unitOfWork, ILectionEventRepository lectionEventRepository, ILectionHeaderRepository lectionHeaderRepository)
        {
            this.unitOfWork = unitOfWork;
            this.lectionEventRepository = lectionEventRepository;
            this.lectionHeaderRepository = lectionHeaderRepository;
        }

        public void Create(LectionEventEntity lectionEvent)
        {
            lectionEventRepository.Add(Mapper.Map<LectionEventEntity, DalLectionEvent>(lectionEvent));
            unitOfWork.Commit();
        }

        public LectionEventEntity GetById(int id)
        {
            return Mapper.Map<DalLectionEvent, LectionEventEntity>(lectionEventRepository.GetById(id));
        }

        public void Update(LectionEventEntity lectionEvent)
        {
            lectionEventRepository.Update(Mapper.Map<LectionEventEntity, DalLectionEvent>(lectionEvent));
            unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            lectionEventRepository.Delete(h => h.Id == id);
            unitOfWork.Commit();
        }

        public void Delete(LectionEventEntity lectionEvent)
        {
            lectionEventRepository.Delete(Mapper.Map<LectionEventEntity, DalLectionEvent>(lectionEvent));
            unitOfWork.Commit();
        }

        public void DeleteEventsOfHeader(int id)
        {
            foreach (var lectionEvent in lectionEventRepository.GetMany(e => e.LectionHeaderId == id))
            {
                Delete(Mapper.Map<DalLectionEvent, LectionEventEntity>(lectionEvent));
            }
        }
        
        public LectionHeaderEntity GetHeaderById(int id)
        {
            var headerId = lectionEventRepository.GetById(id)?.LectionHeaderId;
            if (headerId == null) return null;
            var header = lectionHeaderRepository.GetById((int) headerId);
            return Mapper.Map<DalLectionHeader,LectionHeaderEntity>(header);
        }

        public IEnumerable<LectionEventEntity> GetEventsByHeaderId(int id)
        {
            return lectionEventRepository.GetMany(x => x.LectionHeaderId == id).Select(Mapper.Map<DalLectionEvent,LectionEventEntity>).ToList();
        }
    }
}
