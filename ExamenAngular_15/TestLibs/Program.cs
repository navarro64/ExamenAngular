using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using Api_Wheatear;
using ObjetosNegocio;
using Newtonsoft.Json;

namespace TestLibs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Prueba de metodos de api de climas");
            // primera prueba de obtener  la consutla de conumode la api
            WheatearsNeg obj = new WheatearsNeg();
            //obj.getTemperatureDefault();  


            // consulta de un mes de  clima
            //var asd =  obj.getSingleDay(new DateTime(2018, 7, 1)); 


            // obtienes  una list ade 30 dias 
            //var result = obj.GetMonthWheatear(DateTime.Now);

            //ParamWeather objclima = new ParamWeather(); 
            //string json = JsonConvert.SerializeObject(objclima); 
            //Console.WriteLine(json);


            //List<string> lista =obj.GetMonthWheatearAsync(DateTime.Now, "cajeme");

            Console.ReadKey();

        }
    }
}
