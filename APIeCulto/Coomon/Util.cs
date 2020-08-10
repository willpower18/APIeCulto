using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIeCulto.Coomon
{
    public class Util
    {
        public static DateTime BrasilDate()
        {
            string system = System.Environment.OSVersion.ToString();
            if (system.Contains("Windows"))
            {
                return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));
            }
            else
            {
                return TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("America/Sao_Paulo"));
            }
        }
    }
}
