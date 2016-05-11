using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
   public class HttpResult
    {
       public HttpResult(string message, bool result) 
       {
           Success = result;
           Message = message;
         
       }
       public bool Success { get; set; }
       public string Message { get; set; }
    }
}
