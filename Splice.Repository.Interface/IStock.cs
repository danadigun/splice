using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Repository.Interface
{
    public interface IStock
    {
        int CreateStock(Stock stock);
        void AddItemsToStock(int stockId, List<StockItems> items);
        object GetStockWithItems(int stockId);
        bool removeStock(int stockId);
        bool removeItemFromStock(int itemId);
    }
}
