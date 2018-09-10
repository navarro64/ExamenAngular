using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesLibs.WheatearInt
{
    public interface IWheatear
    {
       string getTemperatureDefault(); 
       Task<string> getSingleDay(DateTime fecha, string cityName);
       Task<List<string>> GetMonthWheatear(DateTime inicio, string cityName);

    }
}
