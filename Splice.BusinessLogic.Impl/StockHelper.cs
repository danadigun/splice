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
using System.Transactions;

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
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
            {
                try
                {
                    stock.CreatedTime = DateTime.Now;
                    stock.LastUpdateTime = DateTime.Now;
                    stock.Deleted = 0;
                    _stockRepo.Save(stock);
                    scope.Complete();
                }


                catch (Exception ex)
                {
                    scope.Dispose();
                    throw ex;
                }
            }
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
                item.CreatedTime = DateTime.Now;
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
            var stockItems = _stockItemsRepo.FetchAll(x => x.StockId == stockId);

            var stockWithItems = new StockWithItemsDTO
            {
                DateCreated = stock.CreatedTime,
                StockId = stock.Id,
                StockTitle = stock.Title,
                StockItemsList = stockItems,
            };

            return stockWithItems;
        }
        /// <summary>
        /// Get AllStockWithItems
        /// </summary>
        /// <returns></returns>
        public object GetAllStockWithItems()
        {
            var allStock = new List<object>();
            var stock = _stockRepo.FetchAll();

            foreach (var item in stock)
            {
                allStock.Add(this.GetStockWithItems(item.Id));
            }
            return allStock;
        }

        /// <summary>
        /// Get AllStock
        /// </summary>
        /// <returns></returns>
        public IList<Stock> GetAllStock()
        {
            return _stockRepo.FetchAll();
        }

        /// <summary>
        /// Get AllProducts
        /// </summary>
        /// <returns></returns>
        public IList<StockItems> GetAllProducts()
        {
            var products = _stockItemsRepo.FetchAll();
            return products;
        }
        /// <summary>
        /// Remove Stock by Id
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove Item From Stock by itemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public bool RemoveItemFromStock(int itemId)
        {
            _stockItemsRepo.Delete(itemId);
            return true;
        }




    }
}
