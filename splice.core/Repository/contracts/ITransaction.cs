using splice.core.Repository.data.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splice.core.Repository.contracts
{
    public interface ITransaction 
    {
        void CreateTransaction(SalesTransaction transaction);

        void AddItemsToTransaction(int transactionId, List<SalesTransactionItem> items);

        object GetTransactionWithItems(int transactionId);

        bool removeTransaction(int transactionId);
    }
}
