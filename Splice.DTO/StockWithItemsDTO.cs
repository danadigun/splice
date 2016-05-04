using Splice.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
   /// <summary>
   /// DTO to return stock with items
   /// </summary>
   public class StockWithItemsDTO
   {
       public int StockId { get; set; }
       public string StockTitle { get; set; }
       public DateTime DateCreated { get; set; }
       public List<StockItems> StockItemsList { get; set; }

   }
}
