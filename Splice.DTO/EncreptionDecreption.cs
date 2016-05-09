using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splice.DTO
{
    public static class EncreptionDecreption
    {
        public static string EncreptedPassword(this string password)
        {
            UTF8Encoding Encoder = new UTF8Encoding();
            byte[] passwordArray = Encoder.GetBytes(password).ToArray();
            string EncreptedPass = Convert.ToBase64String(passwordArray);
            return EncreptedPass;
        }
    }
}
