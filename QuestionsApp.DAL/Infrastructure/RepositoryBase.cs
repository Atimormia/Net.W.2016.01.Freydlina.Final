using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using QuestionsApp.DAL.Interface.DTO;
using QuestionsApp.DAL.Interface.Infrastructure;
using QuestionsApp.ORM.EF;
using QuestionsApp.ORM.Model;

namespace QuestionsApp.DAL.Infrastructure
{
    public abstract class RepositoryBase<TDal,TDomain> 
        where TDal : class
        where TDomain : class
    {
        private ApplicationDbContext dataContext;
        private IDbSet<TDomain> dbset { get; set; }
        
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<TDomain>();
        }

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        protected ApplicationDbContext DataContext => dataContext ?? (dataContext = DatabaseFactory.Get());

        public virtual void Add(TDal entity)
        {
            var domainEntity = Mapper.Map<TDal, TDomain>(entity);
            dbset.Add(domainEntity);
            dataContext.Entry(domainEntity).State = EntityState.Added;
        }

        public virtual void Update(TDal entity)
        {
            var domainEntity = Mapper.Map<TDal, TDomain>(entity);
            dbset.Attach(domainEntity);
            dataContext.Entry(domainEntity).State = EntityState.Modified;
        }
        
        public virtual void Delete(TDal entity)
        {
            var domain = Mapper.Map<TDal, TDomain>(entity);
            dbset.Remove(domain);
        }

        public virtual void DeleteById(long id)
        {
            dbset.Remove(dbset.Find(id));
        }

        public virtual void Delete(Expression<Func<TDal, bool>> where)
        {
            var whereFunc = where.Compile();
            Func<TDomain,bool> whereConverted = u => whereFunc(Mapper.Map<TDomain,TDal>(u));
            var objects = dbset.Where(whereConverted).ToList();
            foreach (TDomain obj in objects)
            {
                dbset.Remove(obj);
            }
        }

        public virtual TDal GetById(long id)
        {
                return Mapper.Map<TDomain,TDal>(dbset.Find(id));
        }

        public virtual TDal GetById(string id)
        {
            try
            {
                var a = Mapper.Map<TDomain,TDal>(dbset.Find(id));
                return a;
            }
            catch (InvalidOperationException e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public virtual IEnumerable<TDal> GetAll()
        {
            return dbset.ToList().Select(Mapper.Map<TDomain,TDal>);
        }

        public virtual IEnumerable<TDal> GetMany(Expression<Func<TDal, bool>> where)
        {
            var dals = dbset.Select(Mapper.Map<TDomain, TDal>).ToList();
            var result = dals.Where(where.Compile()).ToList();
            return result;
        }

        /// <summary>
        /// Return a paged list of entities
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="page">Which page to retrieve</param>
        /// <param name="where">Where clause to apply</param>
        /// <param name="order">Order by to apply</param>
        /// <returns></returns>
        //public virtual IPagedList<T> GetPage<TOrder>(Page page, Expression<Func<T, bool>> where, Expression<Func<T, TOrder>> order)
        //{
        //    var results = dbset.OrderBy(order).Where(where).GetPage(page).ToList();
        //    var total = dbset.Count(where);
        //    return new StaticPagedList<T>(results, page.PageNumber, page.PageSize, total);
        //}

        public TDal Get(Expression<Func<TDal, bool>> where)
        {
            //dataContext.Entry().Reload();
            var enumerable = dbset.Select(Mapper.Map<TDomain, TDal>).ToList();
            var filtered = enumerable.Where(where.Compile()).ToList();
            var result = filtered.FirstOrDefault();
            return result;
        }
        
        
    }

    
}
