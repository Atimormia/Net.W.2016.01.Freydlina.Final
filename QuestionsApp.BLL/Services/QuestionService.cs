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
        private ILectionEventRepository lectionEventRepository;

        public QuestionService(IUnitOfWork unitOfWork, IQuestionRepository questionRepository, ILectionEventRepository lectionEventRepository)
        {
            this.unitOfWork = unitOfWork;
            this.questionRepository = questionRepository;
            this.lectionEventRepository = lectionEventRepository;
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

        public void LikesInc(int id)
        {
            //var question = questionRepository.GetById(id);
            //questionRepository.Delete(question);
            //unitOfWork.Commit();
            //question.Likes = question.Likes + 1;
            //questionRepository.Update(question);
            //unitOfWork.Commit();
        }
        
        public QuestionEntity GetById(int id)
        {
            var result = questionRepository.GetById(id);
            unitOfWork.Commit();
            return Mapper.Map<DalQuestion, QuestionEntity>(result);
        }

        public IEnumerable<QuestionEntity> GetManyOrdered(Expression<Func<QuestionEntity, bool>> where)
        {
            return
                questionRepository.GetAll()
                    .Select(Mapper.Map<DalQuestion, QuestionEntity>)
                    .Where(where.Compile()).OrderByDescending(x => x.Likes)
                    .ToList();
        }
    }
}
