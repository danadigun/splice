using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
    public class ExpenseDTO
    {
        public int ExpenseId { get; set; }
        public string ExpenseTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<ExpenseItems> Items { get; set; }
    }

    public class ExpenseWithItems
    {
        public int ExpenseId { get;set; }
        public string ExpenseTitle { get; set; }
        public DateTime DateCreated { get; set; }
        public IList<ExpenseItems> ExpenseItems { get; set; }
    }
}
