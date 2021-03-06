﻿using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.Repository.Interface
{
    public interface ITransaction
    {
        int CreateTransaction(SalesTransaction transaction);

        void AddItemsToTransaction(int transactionId, List<SalesTransactionItem> items);
        int AddItemToTransaction(int transactionId, SalesTransactionItem item);
        object GetTransactionWithItems(int transactionId);

        bool removeTransaction(int transactionId);
    }
}
