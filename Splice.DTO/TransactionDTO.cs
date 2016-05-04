using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
    public class TransactionDTO
    {
        public int? TransactionId { get; set; }
        public int? ItemId { get; set; }
        public SalesTransaction SalesTransaction { get; set; }
        public SalesTransactionItem SalesTransactionItem { get; set; }
        public List<SalesTransactionItem> SalesTransactionItemList { get; set; }
    }
}
