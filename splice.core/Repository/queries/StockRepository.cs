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
        public int CreateStock(data.POCOs.Stock stock)
        {
            return _stock.Save(stock);
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

        public void AddItemToStock(int stockId, StockItems item)
        {
            var stock = _stock.GetById(stockId);
            if (stock != null)
            {
                item.StockId = stockId;
                item.dateCreated = DateTime.Now;
                _stockItems.Save(item);
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
        public object GetAllStockWithItems()
        {
            var allStock = new List<object>();
            var stock = _stock.GetAll();

            foreach (var item in stock)
            {
                allStock.Add(this.GetStockWithItems(item.Id));
            }
            return allStock;
        }
        public object GetAllStock()
        {
            return _stock.GetAll();
        }

        public object GetAllProducts()
        {
            var products = _stockItems.GetAll();
            return products;
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