using NHibernate;
using Splice.DomainObjects;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Repository.Impl
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        ISession _seesion;
        public UserRepository(ISession session)
            :base(session)
        {
            _seesion=session;
        }
    }
}
