using System;
using System.Collections.Generic;
using QuestionsApp.BLL.Interface.Entities;

namespace QuestionsApp.BLL.Interface.Services
{
    public interface ILectionHeaderService
    {
        void Create(LectionHeaderEntity lectionHeader);
        LectionHeaderEntity GetById(string id);
        void Update(LectionHeaderEntity header);
        void Delete(int id);
        IEnumerable<LectionHeaderEntity> Search(string searchText);
        IEnumerable<LectionHeaderEntity> GetUserHeaders(int userProfileId);
    }
}
