using Api_Wheatear;
using ObjetosNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ExamenAngular_15.Controllers
{
    public class ApiWeatherController : Controller
    {
        // GET: ApiWeather
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ObtenClima(ParamWeather myJson) {
            try {
                WheatearsNeg acces = new WheatearsNeg();
                if (myJson.DateStart.Year == 1)
                    myJson.DateStart = DateTime.Now;
                List<string> lista = await acces.GetMonthWheatear(myJson.DateStart, myJson.City);
                return Json(new { isSuccess = "ok", listData = lista, fechaServer = DateTime.Now });
            } catch (Exception exp) {
                return Json(new { isSuccess = "error", msn=exp.Message });
            }
           
        }
    }
}