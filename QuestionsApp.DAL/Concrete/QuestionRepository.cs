﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestionsApp.DAL.Infrastructure;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Repository;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DAL.Concrete
{
    public class QuestionRepository:RepositoryBase<DalQuestion,Question>,IQuestionRepository
    {
        public QuestionRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
