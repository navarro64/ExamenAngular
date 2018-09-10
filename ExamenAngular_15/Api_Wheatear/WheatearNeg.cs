using InterfacesLibs.WheatearInt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Wheatear
{
    public class WheatearsNeg : IWheatear
    {
        private IWheatear objWheatear = new Wheatear();

        public Task<List<string>> GetMonthWheatear(DateTime inicio, string cityName)
        {
           return  objWheatear.GetMonthWheatear(inicio, cityName);
        }

        public Task<string> getSingleDay(DateTime fecha, string cityName)
        {
            return objWheatear.getSingleDay(fecha, cityName);
        }

        public string getTemperatureDefault()
        {
            return objWheatear.getTemperatureDefault();
        }
    }
}
