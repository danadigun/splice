using splice.core.Repository.contracts;
using splice.core.Repository.data.POCOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace splice.core.Repository.queries
{
    public class StockRepository : IStock
    {
        private Repository<Stock> _stock;
        private Repository<StockItems> _stockItems;
      
        public StockRepository(IDbConnection db)
        {

            _stock = new Repository<Stock>(db);
            _stockItems = new Repository<StockItems>(db);
        }
        public void CreateStock(data.POCOs.Stock stock)
        {
            _stock.Save(stock);
        }

        public void AddItemsToStock(int stockId, List<StockItems> items)
        {
            var stock = _stock.GetById(stockId);
            if (stock != null)
            {
                foreach (var item in items)
                {
                    item.StockId = stockId;
                    _stockItems.Save(item);
                }
            }
        }
        public object GetStockWithItems(int stockId)
        {
            var stock = _stock.GetById(stockId);
            var stockItems = _stockItems.Get(x => x.StockId == stockId);

            var stockWithItems = new StockWithItems
            {
                dateCreated = stock.dateCreated,
                stockId = stock.Id,
                stockTitle = stock.title,
                items = stockItems,
            };

            return stockWithItems;
        }

        public bool removeStock(int stockId)
        {
            var stock = _stock.GetById(stockId);
            if (stock != null)
            {
                _stock.Delete(stockId);
                _stockItems.Delete(x => x.StockId == stockId);
                return true;
            }
            return false;
        }

        public bool removeItemFromStock(int itemId)
        {
            _stockItems.Delete(itemId);
            return true;
        }
    }
}