using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
    public class StockDTO
    {
        public int? StockId { get; set; }
        public int? ItemId { get; set; }
        public Stock stock { get; set; }
        public List<StockItems> StockItemsList { get; set; }
        public StockItems StockItems { get; set; }
    }
}
