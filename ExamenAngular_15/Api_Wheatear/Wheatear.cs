 
using System.Collections.Generic;
using System.Linq;
using System.Text; 

using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GlobalVValues;
using InterfacesLibs.WheatearInt;

namespace Api_Wheatear
{
    internal class Wheatear : IWheatear
    { 
        /// <summary>
        /// Prueba de formato de fechas
        /// </summary>
        /// <returns></returns>
        public string getTemperatureDefault() {
            Task<string> obj;
            string cityvalue = "cajeme";
            string startdate = "2018-09-05";  //YYYY-MM-DD
            string enddate = "2018-09-06";    //YYYY-MM-DD
            string keyvalue = GlobalVValues.WeatherValues.KeyApi;
            string urlfull = String.Format("https://api.weatherbit.io/v2.0/history/daily?city={0}&start_date={1}&end_date={2}&key={3}", cityvalue, startdate, enddate, keyvalue);

            obj = this.GetWheatearAsync(urlfull) ;
            return "";
        }

        /// <summary>
        /// metodo privado para la  consulta del servicio ,
        /// consulta principal en donde se consulta las temperatucas
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private async Task<string> GetWheatearAsync(string path)
        {
          string myContent = ""; 
            using (HttpClient client = new HttpClient()) {
                using (HttpResponseMessage respond = await client.GetAsync(path))
                {
                    using (HttpContent content = respond.Content) {
                        myContent = await content.ReadAsStringAsync();
                    }
                }
            }
            return myContent;
        }

        /// <summary>
        /// obtienes la consluta de un dia n espesifico, armando la cadena de consulta
        /// </summary>
        /// <param name="fecha"></param>
        /// <returns></returns>
        public async Task<string> getSingleDay(DateTime fecha, string cityName) {
            // string cityvalue = "cajeme";
            string cityvalue = cityName;
            string startdate = fecha.ToString("yyyy-MM-dd");  //YYYY-MM-DD
            string enddate = fecha.AddDays(1).ToString("yyyy-MM-dd");    //YYYY-MM-DD
            string keyvalue = GlobalVValues.WeatherValues.KeyApi;
            string path=String.Format("https://api.weatherbit.io/v2.0/history/daily?city={0}&start_date={1}&end_date={2}&key={3}", cityvalue, startdate, enddate, keyvalue);
            string obj= await this.GetWheatearAsync(path); 
            return obj;
        }

        /// <summary>
        /// Obtienes una lista de historial de 30 dias
        /// </summary>
        /// <param name="inicio"></param>
        /// <returns></returns>
        public async Task<List<string>> GetMonthWheatear(DateTime inicio, string cityName) {
            List<string> listaClima = new List<string>();
            DateTime fecha = inicio;
            for (int token = 0; token < WeatherValues.LimiteFechas; token++)
            {
                var cont="";
                if (token == 0) {
                    fecha = fecha.AddDays(0);
                    //cont = this.getSingleDay(fecha, cityName).GetAwaiter().GetResult();
                    cont = await this.getSingleDay(fecha, cityName);
                }

                if (token > 0) {
                    fecha = fecha.AddDays(-1);
                    //cont = this.getSingleDay(fecha, cityName).GetAwaiter().GetResult();
                    cont = await this.getSingleDay(fecha, cityName);
                }
                if (cont.Contains("status_code\":429") || cont.Contains("Your API key has been restricted") ) {
                    throw new System.ArgumentException("Servidor no diponible");
                }
                listaClima.Add(cont);
            }
            return listaClima;
        }

    }
}
