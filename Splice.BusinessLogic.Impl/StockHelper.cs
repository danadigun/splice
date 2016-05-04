using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using Splice.Repository.Impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Impl
{
    public class StockHelper :IStockHelper
    {
        private Repository<Stock> _stockRepo;
        private Repository<StockItems> _stockItemsRepo;

        public StockHelper(Repository<Stock> stockRepo, Repository<StockItems> stockItemsRepo)
        {
            _stockRepo = stockRepo;
            _stockItemsRepo = stockItemsRepo;
        }

        /// <summary>
        /// Create a new stock
        /// </summary>
        /// <param name="stock"></param>
        public void CreateStock(Stock stock)
        {
            _stockRepo.Save(stock);
        }

        /// <summary>
        /// Add New item in stock
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="items"></param>
        public void AddItemsToStock(int stockId, List<StockItems> items)
        {
            var stock = _stockItemsRepo.GetById(stockId);
            if (stock != null)
            {
                foreach (var item in items)
                {
                    item.StockId = stockId;
                    _stockItemsRepo.Save(item);
                }
            }
        }

        /// <summary>
        /// AddItemToStock
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="item"></param>
        public void AddItemToStock(int stockId, StockItems item)
        {
            var stock = _stockRepo.GetById(stockId);
            if (stock != null)
            {
                item.StockId = stockId;
                item.DateCreated = DateTime.Now;
                _stockItemsRepo.Save(item);
            }

        }

        /// <summary>
        /// Get stock 
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        public StockWithItemsDTO GetStockWithItems(int stockId)
        {
            var stock = _stockRepo.GetById(stockId);
            var stockItems = _stockItemsRepo.Get(x => x.StockId == stockId);

            var stockWithItems = new StockWithItemsDTO
            {
                DateCreated = stock.DateCreated,
                StockId = stock.Id,
                StockTitle = stock.Title,
                StockItemsList = stockItems,
            };

            return stockWithItems;
        }
        public object GetAllStockWithItems()
        {
            var allStock = new List<object>();
            var stock = _stockRepo.GetAll();

            foreach (var item in stock)
            {
                allStock.Add(this.GetStockWithItems(item.Id));
            }
            return allStock;
        }

        public IList<Stock> GetAllStock()
        {
            return _stockRepo.GetAll();
        }

        public IList<StockItems> GetAllProducts()
        {
            var products = _stockItemsRepo.GetAll();
            return products;
        }
        public bool RemoveStock(int stockId)
        {
            var stock = _stockRepo.GetById(stockId);
            if (stock != null)
            {
                _stockRepo.Delete(stockId);
                _stockItemsRepo.Delete(x => x.StockId == stockId);
                return true;
            }
            return false;
        }

        public bool RemoveItemFromStock(int itemId)
        {
            _stockItemsRepo.Delete(itemId);
            return true;
        }




    }
}
