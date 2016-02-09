using splice.core.Repository.data.POCOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splice.core.Repository.contracts
{
    public interface IStock
    {
        void CreateStock(Stock stock);
        void AddItemsToStock(int stockId, List<StockItems> items);
        object GetStockWithItems(int stockId);
        bool removeStock(int stockId);
        bool removeItemFromStock(int itemId);
       
    }
}
