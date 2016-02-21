using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splice.core.Repository.contracts
{
    public interface IRepositoryApi<DTO>
        where DTO : class     
    {
       
        object get(DTO dto);
        object post(DTO dto);
        void put(DTO dto);
        object delete(DTO dto);
    }
}
