using Splice.BusinessLogic.Interface;
using Splice.DomainObjects;
using Splice.DTO;
using Splice.Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.BusinessLogic.Impl
{
    public class TransactionHelper : ITransactionHelper
    {
        private Repository<SalesTransaction> _transactionRepo;
        private Repository<SalesTransactionItem> _transactionItemRepo;
        public TransactionHelper(Repository<SalesTransaction> transactionRepo,Repository<SalesTransactionItem> transactionItemRepo)
        {
            _transactionRepo = transactionRepo;
            _transactionItemRepo = transactionItemRepo;
        }
        public void CreateTransaction(SalesTransaction transaction)
        {
             _transactionRepo.Save(transaction);
        }

        public void AddItemsToTransaction(int transactionId, List<DomainObjects.SalesTransactionItem> items)
        {
            var salesTransaction = _transactionRepo.GetById(transactionId);
            if (salesTransaction != null)
            {
                foreach (var item in items)
                {
                    item.SalesTransactionId = transactionId;
                    _transactionItemRepo.Save(item);
                }
            }
        }

        public void AddItemToTransaction(int transactionId,SalesTransactionItem item)
        {
            var salesTransaction = _transactionRepo.GetById(transactionId);
            if (salesTransaction != null)
            {
                item.SalesTransactionId = transactionId;
                _transactionItemRepo.Save(item);
            }
        }

        public TransactionWithItemsDTO GetTransactionWithItems(int transactionId)
        {
            var salesTransaction = _transactionRepo.GetById(transactionId);
            var salesTransactionItemsList = _transactionItemRepo.Get(x => x.SalesTransactionId == transactionId);

            var transactionWithItems = new TransactionWithItemsDTO
            {
                TransactionId = salesTransaction.Id,
                SoldBy = salesTransaction.SoldBy,
                DateCreated = salesTransaction.DateCreated,
                SalesTransactionItemList = salesTransactionItemsList
            };
            return transactionWithItems;
        }

        public bool RemoveTransaction(int transactionId)
        {
            var salesTransaction = _transactionRepo.GetById(transactionId);
            if (salesTransaction != null)
            {
                _transactionRepo.Delete(transactionId);
                _transactionItemRepo.Delete(x => x.SalesTransactionId == transactionId);
                return true;
            }
            return false;
        }
        public bool RemoveItemFromTransaction(int itemId)
        {
            _transactionItemRepo.Delete(x => x.Id == itemId);
            return true;          
        }
    }
}
