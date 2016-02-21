using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace splice.core.Repository.data.POCOs
{
    public class Stock
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime dateCreated { get; set; }
    }

    public class StockItems
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int StockId { get; set; }
        public string serial { get; set; }
        public string name { get; set; }
        public decimal costPrice { get; set; }
        public decimal sellingPrice { get; set; }
        public int quantity { get; set; }
        public DateTime dateCreated { get; set; }
    }

    /// <summary>
    /// DTO to return stock with items
    /// </summary>
    public class StockWithItems
    {
        public int stockId { get; set; }
        public string stockTitle { get; set; }
        public DateTime dateCreated { get; set; }
        public List<StockItems> items { get; set; }

    }
}