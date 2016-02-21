using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;
using splice.core.Repository.data;
using splice.core.Repository.data.DataSource;
using splice.core.Repository.queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace splice.core.Services
{
    [Route("/api/product")]
    public class ProductDTO
    {
        public int id { get; set; }
    }
    public class ProductService : Service
    {
       
        public object delete(ProductDTO request)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.stockRepo;

                return _repo.removeItemFromStock(request.id);
            }
        }
    }
}