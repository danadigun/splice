using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Repository.Interface
{
    public interface IRepository<T> where T : Base
    {
        /// <summary>
        /// Get all elements of type T
        /// </summary>
        /// <returns></returns>
        IList<T> FetchAll();

        /// <summary>
        /// Get elements that comply to the specified criteria
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        IList<T> FetchAll(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Get element that comply to the specified criteria
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> exp);

        /// <summary>
        /// Get an instance of T with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Inserts or updates instance
        /// </summary>
        /// <param name="entity"></param>
        void Save(T entity);

        /// <summary>
        /// Deletes element with specified id
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// Delete elements that comply to specified criteria
        /// </summary>
        /// <param name="exp"></param>
        void Delete(Expression<Func<T, bool>> exp);

        /// <summary>
        /// check is existed user
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool IsExist(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}
