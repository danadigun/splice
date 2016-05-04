using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.WebHost;


namespace Splice.Web.Api.Controllers
{
    //[Route("/api/sales/stock")]
    //[EnableCors("*", "*", "*")]
    public class StockController : ApiController
    {
        private IStockHelper _stockHelper;
        public StockController(IStockHelper stockHelper)
        {
            _stockHelper = stockHelper;
        }
             
        
        public IList<Stock> Get()
        {
            return _stockHelper.GetAllStock();
        }
                
        public StockWithItemsDTO GetStockWithItems(int stockid)
        {
            return _stockHelper.GetStockWithItems(stockid);
        }

        [HttpPost]
        public bool Post(StockDTO dto)
        {
            if (dto.stock != null)
            {
                _stockHelper.CreateStock(dto.stock);
            }

            //add items to stock
            if (dto.StockItemsList != null && dto.StockId.HasValue)
            {
                _stockHelper.AddItemsToStock(dto.StockId.Value, dto.StockItemsList);
                return true;
            }

            //add one item to stock
            if (dto.StockItems != null && dto.StockId.HasValue)
            {
                _stockHelper.AddItemToStock(dto.StockId.Value, dto.StockItems);
                return true;
            }
            return false;

        }

        public void Put(StockDTO dto)
        {
            throw new NotImplementedException();
        }

        public object Delete(StockDTO dto)
        {
            if (dto.StockId.HasValue)
            {
                return _stockHelper.RemoveStock(dto.StockId.Value);
            }

            //remove items from stock
            if (dto.ItemId.HasValue)
            {
                return _stockHelper.RemoveItemFromStock(dto.ItemId.Value);
            }
            return false;
        }
    }
}
