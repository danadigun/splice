using Splice.BusinessLogic.Interface;
using Splice.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Splice.Web.Api.Controllers
{
    public class TransactionController : ApiController
    {
        private ITransactionHelper _transactionHelper;
        public TransactionController(ITransactionHelper transactionHelper)
        {
            _transactionHelper = transactionHelper;
        }
        public TransactionWithItemsDTO get(int transactionId)
        {
            return _transactionHelper.GetTransactionWithItems(transactionId);
        }

        public bool Post(TransactionDTO dto)
        {
            //CreateTransaction
            if (dto.SalesTransaction != null)
            {
                dto.SalesTransaction.DateCreated = DateTime.Now;
                _transactionHelper.CreateTransaction(dto.SalesTransaction);
            }

            //AddItemsToTransaction
            if (dto.TransactionId.HasValue && dto.SalesTransactionItemList != null)
            {
                _transactionHelper.AddItemsToTransaction(dto.TransactionId.Value, dto.SalesTransactionItemList);
                return true;
            }

            //AddItem to Transaction
            if (dto.TransactionId.HasValue && dto.SalesTransactionItem != null)
            {
                _transactionHelper.AddItemToTransaction(dto.TransactionId.Value, dto.SalesTransactionItem);
                //return true;
            }
            return true;
        }

        public void Delete(TransactionDTO dto)
        {
            if (dto.TransactionId.HasValue)
            {
                _transactionHelper.RemoveTransaction(dto.TransactionId.Value);
            }
            if (dto.ItemId.HasValue)
            {
                _transactionHelper.RemoveItemFromTransaction(dto.ItemId.Value);                
            }            
        }

        public void Put(TransactionDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
