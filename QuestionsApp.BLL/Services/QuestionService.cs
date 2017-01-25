using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using QuestionsApp.BLL.Interface.Entities;
using QuestionsApp.BLL.Interface.Services;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.DAL.Interface.Repository;

namespace QuestionsApp.BLL.Services
{
    public class QuestionService: IQuestionService
    {
        private IUnitOfWork unitOfWork;
        private IQuestionRepository questionRepository;

        public QuestionService(IUnitOfWork unitOfWork, IQuestionRepository questionRepository)
        {
            this.unitOfWork = unitOfWork;
            this.questionRepository = questionRepository;
        }

        public IEnumerable<QuestionEntity> GetMany(Expression<Func<QuestionEntity, bool>> where)
        {
            return
                questionRepository.GetAll()
                    .Select(Mapper.Map<DalQuestion, QuestionEntity>)
                    .Where(where.Compile())
                    .ToList();
        }

        public void Create(QuestionEntity question)
        {
            questionRepository.Add(Mapper.Map<QuestionEntity, DalQuestion>(question));
            unitOfWork.Commit();
        }
    }
}
