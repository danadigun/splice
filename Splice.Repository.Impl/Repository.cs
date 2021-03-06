﻿using NHibernate;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using Splice.DomainObjects;
namespace Splice.Repository.Impl
{
    public class Repository<T> : IRepository<T> where T : Base
    {
        public ISession _session;


        public Repository(ISession session)
        {
            this._session = session;
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        public virtual IList<T> FetchAll()
        {
            return _session.Query<T>().ToList();
        }

        /// <summary>
        /// Get a single entity by clause
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public IList<T> FetchAll(Expression<Func<T, bool>> exp)
        {
            return _session.Query<T>().Where(exp).ToList();
        }

        /// <summary>
        /// Get a single entity
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T Get(Expression<Func<T, bool>> expression)
        {
            return _session.Query<T>().FirstOrDefault(expression);
        }

        /// <summary>
        /// Get entity by PK
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(int id)
        {
            return _session.Query<T>().FirstOrDefault(x=>x.Id==id);
        }
             
        /// <summary>
        /// save an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Save(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
           _session.Delete(GetById(id));
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="exp"></param>
        public void Delete(Expression<Func<T, bool>> exp)
        {
            var objects = FetchAll(exp);
            foreach (var item in objects)
            {
                this.Delete(item.Id);
            }
        }

        /// <summary>
        /// IsExist
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public bool IsExist(Expression<Func<T, bool>> expression)
        {
            var qureyResults = _session.Query<T>().Where(expression);
            return (qureyResults != null && qureyResults.Count() > 0);
        }
        public void Update(T entity)
        {
            Base baseObject = (Base)entity;
            baseObject.LastUpdateTime = DateTime.Now;
            _session.SaveOrUpdate(entity);
        }
    }
}
