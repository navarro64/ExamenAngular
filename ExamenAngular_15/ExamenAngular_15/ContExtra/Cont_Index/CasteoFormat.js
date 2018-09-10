
// obtienes el formato de  dd/mm/aaaa  de un objeto fecha de angular
function formatoFecha(tmpdate) {
    if (tmpdate === "" || tmpdate === undefined || tmpdate === null)
        return "null";
    return tmpdate.getDate() + "-" + tmpdate.getMonth() + "-" + tmpdate.getFullYear();
}



function ObtenFormatojson(city, dateStart) {
    var ParamWeather = {  City: city,  DateStart: dateStart  };
    return ParamWeather;
}


// obtenemos una lita  de tipo STRING y las juntamos y casteamos a una lista de tipo JSONo Array
function ObtenListaJsonFuenteCadena(datos) {
    var listaClima = [];
    for (i = 0; i < datos.length; i++) {
        listaClima.push(JSON.parse(datos[i]) );
    }
    return listaClima;
}