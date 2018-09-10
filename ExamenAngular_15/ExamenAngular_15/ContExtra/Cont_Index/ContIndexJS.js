var app = angular.module('myApp', []);
app.controller('myCtrl', function ($scope, $http) {
    $scope.email = "asdasd";
    $scope.citySelect = "cajeme";
    $scope.tipoMedicion = "Celsius";
    $scope.datevalue = "";
    $scope.listaClima = [];
    $scope.ListaVertical = [];

    //Obtienes lo parametros para la tabla
    $scope.obtenParametros = function () { 
        var ParamWeather = JSON.stringify (ObtenFormatojson($scope.citySelect, $scope.datevalue) )
        var url ="ApiWeather/ObtenClima";
        var data = ParamWeather;
        var config = { headers: { "Content-Type": "application/json" } };
        $http.post(url, data, config).then(successCallback, errorCallback);
        function successCallback(req) { 
            $scope.CargarParametrosVista(req); 
        }
        function errorCallback(req) {
            alert("error");
        } 
        //alert("---" + $scope.citySelect + "---" + $scope.tipoMedicion + "---" + formatoFecha($scope.datevalue));
    };

    $scope.CambioTemperatura = function () {
        if ($scope.tipoMedicion === "Fahrenheit") {
            cambioTemperaturaMedicionFarenheins($scope.listaClima, $scope.listaClima[0].city_name);
            $scope.CargarTablaVertical();
        } else {
            cambioTemperaturaMedicionCelsius($scope.listaClima, $scope.listaClima[0].city_name);
            $scope.CargarTablaVertical();
        }
    }

    // da inicio un conjunto de procesos para cargar los datos en la pantalla
    $scope.CargarParametrosVista = function (req) {
        if (req.data.isSuccess === "ok") { 
            mystring = req.data.fechaServer.replace('/Date(', '');
            mystring = mystring.replace(')/', '');
            mystring = parseInt(mystring);
            $scope.datevalue = new Date(mystring); 

            $scope.listaClima = ObtenListaJsonFuenteCadena(req.data.listData)
            CargarDatosTabl($scope.listaClima, $scope.listaClima[0].city_name);
            $scope.CargarTablaVertical();
        } else {
            alert("ERROE EN LA CONSULTA " + req.data.msn);
        }
    }

    $scope.CargarTablaVertical = function () { 
        if ($scope.listaClima === undefined || $scope.listaClima === null || $scope.listaClima.length === 0)
            return false;
        $scope.ListaVertical = obtenFormatoTablaMedicionVertical($scope.tipoMedicion, $scope.listaClima); 
        var asasdasad = "asd";
    }


    //........................INICIO DE ANGULAR
    $scope.obtenParametros();
    //.......................INICIO DE ANGULAR


});