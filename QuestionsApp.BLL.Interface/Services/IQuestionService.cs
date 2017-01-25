using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using QuestionsApp.BLL.Interface.Entities;

namespace QuestionsApp.BLL.Interface.Services
{
    public interface IQuestionService
    {
        IEnumerable<QuestionEntity> GetMany(Expression<Func<QuestionEntity, bool>> where);
        void Create(QuestionEntity question);
    }
}
