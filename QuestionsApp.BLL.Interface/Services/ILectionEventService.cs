using System;
using QuestionsApp.BLL.Interface.Entities;

namespace QuestionsApp.BLL.Interface.Services
{
    public interface ILectionEventService : IDisposable
    {
        void Create(LectionEventEntity lectionEvent);
        LectionEventEntity GetById(string id);
        void Update(LectionEventEntity lectionEvent);
        void Delete(string id);
        void DeleteEventsOfHeader(int id);
        LectionHeaderEntity GetHeaderById(string id);
    }
}
