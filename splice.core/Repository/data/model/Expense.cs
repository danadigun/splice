using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace splice.core.Repository.data.POCOs
{

    public class Expense
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string title { get; set; }
        public DateTime dateCreated { get; set; }
    }

    public class ExpenseItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public string itemName { get; set; }
        public decimal price { get; set; }
        public DateTime dateCreated { get; set; }
    }

    /// <summary>
    /// DTO to return upon request for expenses
    /// </summary>
    public class ExpenseWithItems
    {
        public int expenseId { get; set; }
        public string expenseTitle { get; set; }
        public DateTime dateCreated { get; set; }
        public List<ExpenseItems> items { get; set; }
    }
}