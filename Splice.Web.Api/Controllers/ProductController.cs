using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Splice.Web.Api.Controllers
{
    public class ProductController : ApiController
    {
        private IStockHelper _stockHelper;
        public ProductController(IStockHelper stockHelper)
        {
            _stockHelper = stockHelper;
        }

        public bool Delete(int productId)
        {
            return _stockHelper.RemoveItemFromStock(productId);
        }

        public IList<StockItems> Get()
        {
            return _stockHelper.GetAllProducts();
        }
    }
}
