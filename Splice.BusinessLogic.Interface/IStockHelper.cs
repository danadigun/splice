using Splice.DomainObjects;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Splice.BusinessLogic.Interface
{
    public interface IStockHelper
    {
        /// <summary>
        /// create a new stock
        /// </summary>
        /// <param name="stock"></param>
        void CreateStock(Stock stock);

        /// <summary>
        /// Add New item in stock
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="items"></param>
        void AddItemsToStock(int stockId, List<StockItems> items);

        /// <summary>
        /// AddItemToStock
        /// </summary>
        /// <param name="stockId"></param>
        /// <param name="item"></param>
        void AddItemToStock(int stockId, StockItems item);

        /// <summary>
        /// GetStockWithItems
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        StockWithItemsDTO GetStockWithItems(int stockId);

        /// <summary>
        /// Get all stock with items
        /// </summary>
        /// <returns></returns>
        object GetAllStockWithItems();

        /// <summary>
        /// Get all stock
        /// </summary>
        /// <returns></returns>
        IList<Stock> GetAllStock();

        /// <summary>
        /// Get all products
        /// </summary>
        /// <returns></returns>
        IList<StockItems> GetAllProducts();

        /// <summary>
        /// Remove stock by stockId
        /// </summary>
        /// <param name="stockId"></param>
        /// <returns></returns>
        bool RemoveStock(int stockId);

        /// <summary>
        /// Remove item from itemId
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        bool RemoveItemFromStock(int itemId);
    }
}
