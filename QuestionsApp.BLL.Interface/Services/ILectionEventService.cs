using System;
using System.Collections.Generic;
using QuestionsApp.BLL.Interface.Entities;

namespace QuestionsApp.BLL.Interface.Services
{
    public interface ILectionEventService
    {
        void Create(LectionEventEntity lectionEvent);
        LectionEventEntity GetById(int id);
        void Update(LectionEventEntity lectionEvent);
        void Delete(int id);
        void Delete(LectionEventEntity lectionEvent);
        void DeleteEventsOfHeader(int id);
        LectionHeaderEntity GetHeaderById(int id);
        IEnumerable<LectionEventEntity> GetEventsByHeaderId(int id);
    }
}
