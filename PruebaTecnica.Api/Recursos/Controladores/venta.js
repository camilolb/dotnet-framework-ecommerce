(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("VentaController", function ($scope, VentaService, ProductoService) {

        $scope.venta = {};
        $scope.listaVentas = [];
        $scope.producto = {};
        

        // Metodos de carga
        //CargarVentas();

        $scope.crear = function (venta)
        {
            var resultado = VentaService.guardar(venta);
            resultado.then(success, error);

            function success(e) {

                var resultado = angular.fromJson(e.data);

                if (resultado) {
                    alert("Venta guardada exitosamente");
                    location.reload();
                }
            }

            function error(e) {
                alert("Error al guardar la venta");
            }
        };

        $scope.productoPorCodigo = function (code)
        {
            ProductoService.obtenerPorCodigo(code).then(function (e)
            {
                var producto = angular.fromJson(e.data);
                $scope.producto = producto;
            });
        }

    });


    app.service("VentaService", function ($http, $q) {

        this.obtenerVentas = function () {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('./api/Sales', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);
            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);
            };

            return response.promise;
        }

        this.guardar = function (venta) {

            var response = $q.defer();

            var data = venta;
            var config = {};

            $http.post('./api/Sales', data, config).then(successCallback, errorCallback);

            function successCallback(e) {

                var resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }

                response.resolve(resultado);

            };

            function errorCallback(e) {

                var resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }

                response.reject(resultado);

            };

            return response.promise;
        };

    });

})();

