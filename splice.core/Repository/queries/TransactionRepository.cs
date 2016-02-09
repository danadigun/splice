using splice.core.Repository.contracts;
using splice.core.Repository.data.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace splice.core.Repository.queries
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
        public void CreateTransaction(data.model.SalesTransaction transaction)
        {
            _transaction.Save(transaction);
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
    }
}