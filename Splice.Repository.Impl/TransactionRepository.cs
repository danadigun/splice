using Splice.DomainObjects;
using Splice.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Repository.Impl
{
    public class TransactionRepository : ITransaction
    {
        private Repository<SalesTransaction> _transaction;
        private Repository<SalesTransactionItem> _transactionItem;
        public TransactionRepository(IDbConnection db)
        {
            _transaction = new Repository<SalesTransaction>(db);
            _transactionItem = new Repository<SalesTransactionItem>(db);
        }
        public int CreateTransaction(data.model.SalesTransaction transaction)
        {
            return _transaction.Save(transaction);

        }

        public void AddItemsToTransaction(int transactionId, List<data.model.SalesTransactionItem> items)
        {
            var transaction = _transaction.GetById(transactionId);
            if (transaction != null)
            {
                foreach (var item in items)
                {
                    item.SalesTransactionId = transactionId;
                    _transactionItem.Save(item);
                }
            }
        }
        public int AddItemToTransaction(int transactionId, SalesTransactionItem item)
        {
            var transaction = _transaction.GetById(transactionId);
            if (transaction != null)
            {
                item.SalesTransactionId = transactionId;
                return _transactionItem.Save(item);
            }
            return 0;
        }
        public object GetTransactionWithItems(int transactionId)
        {
            var transaction = _transaction.GetById(transactionId);
            var transactionItems = _transactionItem.Get(x => x.SalesTransactionId == transactionId);

            var transactionWithItems = new TransactionWithItems
            {
                transactionId = transaction.Id,
                soldBy = transaction.soldby,
                dateCreated = transaction.dateCreated,
                transactionItems = transactionItems
            };
            return transactionWithItems;
        }

        public bool removeTransaction(int transactionId)
        {
            var transaction = _transaction.GetById(transactionId);
            if (transaction != null)
            {
                _transaction.Delete(transactionId);
                _transactionItem.Delete(x => x.SalesTransactionId == transactionId);
                return true;
            }
            return false;
        }

        public bool removeItemFromTransaction(int itemId)
        {
            _transactionItem.Delete(x => x.Id == itemId);
            return true;
        }

    }
}
