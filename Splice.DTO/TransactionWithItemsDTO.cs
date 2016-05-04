using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
    public class TransactionWithItemsDTO
    {
        public int TransactionId { get; set; }
        public DateTime DateCreated { get; set; }
        public string SoldBy { get; set; }
        public List<SalesTransactionItem> SalesTransactionItemList { get; set; }
    }
}
