
function CARGAR_TABLA_CHART(listaFechas, listaTemp, ciudad) {
    new Chart(document.getElementById("line-chart"), {
        type: 'line',
        data: {
            labels: listaFechas,
            datasets: [{
                data: listaTemp,
                label: ciudad,
                borderColor: "#3e95cd",
                fill: false
            }]
        },
        options: {
            title: {
                display: true,
                text: 'World population per region'
            }
        }
    });
}

// arga losd atos acia la tabla "por defaul,, la medicion es Celsius  por el servidor"
function CargarDatosTabl(lista, ciudad) { 
    var listaFechas = ObtenListaFechas(lista);
    var listaTemp = ObtenListaTemperatura(lista);
    CARGAR_TABLA_CHART(listaFechas, listaTemp, ciudad );
}

//Carlos dos datos a Celcius
function cambioTemperaturaMedicionFarenheins(lista, ciudad) {
    var listaFechas = ObtenListaFechas(lista);
    var listaTemp = ObtenListaTemperatura(lista);
    listaTemp = convertFahrenheit(listaTemp);
    CARGAR_TABLA_CHART(listaFechas, listaTemp, ciudad);
}
//Carlos dos datos a Celcius
function cambioTemperaturaMedicionCelsius(lista, ciudad) {
    var listaFechas = ObtenListaFechas(lista);
    var listaTemp = ObtenListaTemperatura(lista);
    listaTemp = convertCelsius(listaTemp);
    CARGAR_TABLA_CHART(listaFechas, listaTemp, ciudad);
}


// regresa  dos listas,, 1 lista de temperaturas con formato  y lista de fechas
function obtenFormatoTablaMedicionVertical(medicion, listatemperatura) { 
    var listaFechas = ObtenListaFechas(listatemperatura);
    var listaTemp = ObtenListaTemperatura(listatemperatura);
    if (medicion ==="Fahrenheit")
        listaTemp = convertFahrenheit(listaTemp); 
    return { listaTemp: listaTemp, listaFechas: listaFechas };
}

// regresa el valor convertido e Celsius
function convertCelsius(valorList) { 
    for (i = 0; i < valorList.length; i++) {
        valorList[i] = (valorList[i] - 32) * 5 / 9;
        valorList[i] = Math.round(valorList[i]);
    }
    return valorList;
}
// regresa el valor convertido e Fahrenheit
function convertFahrenheit(valorList) {
    for (i = 0; i < valorList.length; i++) {
        valorList[i] = valorList[i] * 9 / 5 + 32;
        valorList[i] = Math.round(valorList[i]);
    } 
    return valorList;
    //return x = (valor - 32) * 5 / 9;
}


// obtienes la lista de fechas de temperaturas
function ObtenListaFechas(dataList) {
    var listaFecha = [];  
    for (i = 0; i < dataList.length; i++) {
        listaFecha.push(dataList[i].data[0].datetime);
    } 
    return listaFecha;
}
// obtienes la lista de temperaturas
function ObtenListaTemperatura(dataList) {
    var listaTemperatura = [];
    for (i = 0; i < dataList.length; i++) {
        listaTemperatura.push(dataList[i].data[0].temp);
    } 
    return listaTemperatura;
}


