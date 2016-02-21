using splice.core.Repository.contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;

namespace splice.core.Repository
{
    public class Repository<T> : IRepository<T> where T : new()
    {
        public IDbConnection db;

       
        public Repository(IDbConnection db)
        {
            this.db = db;
        }

        public virtual List<T> GetAll()
        {
            return db.Select<T>();
        }

        public List<T> Get(Expression<Func<T, bool>> exp)
        {
            return db.Select<T>(exp);
        }

        public virtual T GetById(int id)
        {
            var o = db.GetById<T>(id);
            return o;
        }

        public virtual T GetById(string id)
        {
            var o = db.GetById<T>(id);
            return o;
        }


        public int Save(T o)
        {
            db.Save<T>(o);
            return Convert.ToInt32(db.GetLastInsertId()); //returns the inserted Id;
        }

        public void Delete(int id)
        {
            var o = db.GetById<T>(id);
            if (o != null)
            {
                db.Delete(o);
            }
        }

        public void Delete(Expression<Func<T, bool>> exp)
        {
            db.Delete<T>(exp);
        }
    }
}