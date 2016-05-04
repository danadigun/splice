using Splice.DomainObjects;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Interface
{
    public interface ITransactionHelper
    {
        void CreateTransaction(SalesTransaction transaction);

        void AddItemsToTransaction(int transactionId, List<SalesTransactionItem> items);

        void AddItemToTransaction(int transactionId, SalesTransactionItem item);

        TransactionWithItemsDTO GetTransactionWithItems(int transactionId);

        bool RemoveTransaction(int transactionId);

        bool RemoveItemFromTransaction(int itemId);
    }
}
