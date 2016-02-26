using ServiceStack.ServiceInterface;
using splice.core.Repository.contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using splice.core.Repository.data.model;
using splice.core.Repository.queries;
using System.Data;
using ServiceStack.ServiceHost;
using splice.core.Repository.data;
using splice.core.Repository.data.DataSource;

namespace splice.core.Services
{
    [Route("/api/sales/transaction")]
    public class TransactionDTO
    {
        public int? transactionId { get; set; }
        public SalesTransaction transaction { get; set; }
        public SalesTransactionItem item { get; set; }
        public List<SalesTransactionItem> items { get; set; }
    }
    
    public class TransactionService : Service, IRepositoryApi<TransactionDTO>
    {        
       
        public object get(TransactionDTO dto)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.transactionRepo;

                if (dto.transactionId.HasValue)
                {
                    return _repo.GetTransactionWithItems(dto.transactionId.Value);
                }
                return "no transaction requested";
            }
        }

        public object post(TransactionDTO dto)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.transactionRepo;

                //CreateTransaction
                if (dto.transaction != null)
                {
                    dto.transaction.dateCreated = DateTime.Now;
                   return  _repo.CreateTransaction(dto.transaction);                   
                }

                //AddItemsToTransaction
                if (dto.transactionId.HasValue && dto.items != null)
                {
                    _repo.AddItemsToTransaction(dto.transactionId.Value, dto.items);
                    return true;
                }

                //AddItem to Transaction
                if (dto.transactionId.HasValue && dto.item != null)
                {
                    _repo.AddItemToTransaction(dto.transactionId.Value, dto.item);
                    return true;
                }

                return false;
            }
       
        }

        public void put(TransactionDTO dto)
        {
            throw new NotImplementedException();
        }

        public object delete(TransactionDTO dto)
        {
            using (var uow = new UnitOfWork(DataSource.sqlConnectionString))
            {
                var _repo = uow.transactionRepo;
                return _repo.removeTransaction(dto.transactionId.Value);
            }
        }
    }
}