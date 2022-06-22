(function () {

    var app = angular.module('pruebaTecnica');


    app.controller("ProductoController", function ($scope, ProductoService) {

        $scope.producto = {};
        $scope.listaProductos = [];

        // Metodos de carga
        CargarProductos();

        $scope.crear = function (producto)
        {
            producto.code = Math.random().toString(36).replace(/[^a-z]+/g, '').substr(0, 5);
            var resultado = ProductoService.guardar(producto);
            resultado.then(success, error);

            function success(e) {

                var resultado = angular.fromJson(e.data);

                if (resultado) {
                    alert("Producto guardada exitosamente");
                    location.reload();
                }
            }

            function error(e) {
                alert("Error al guardar el producto");
            }
        };

        function CargarProductos()
        {
            ProductoService.obtenerProductos().then(function (e)
            {
                debugger;
                var lista = angular.fromJson(e.data);
                debugger;
                if (lista != null && lista.data.length > 0)
                {
                    $scope.listaProductos = lista.data;
                } else {
                    $scope.listaProductos = "No hay ninguna clasificación creada recientemente.";
                }
            });
        }

    });


    app.service("ProductoService", function ($http, $q) {

        this.obtenerProductos = function () {

            var response = $q.defer();

            var data = {};
            var config = {};

            $http.get('https://localhost:5001/api/product', data, config).then(successCallback, errorCallback);

            function successCallback(e) {
                const resultado = {
                    error: false
                    , mensaje: ""
                    , data: e.data
                }
                response.resolve(resultado);
            };

            function errorCallback(e) {
                const resultado = {
                    error: true
                    , mensaje: ""
                    , data: e.data
                }
                response.reject(resultado);
            };

            return response.promise;
        }

        this.obtenerPorCodigo = function (code) {

            var response = $q.defer();

            var data = code;
            var config = {};

            $http.get('https://localhost:5001/api/product', data, config).then(successCallback, errorCallback);

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
        this.guardar = function (producto) {

            var response = $q.defer();

            var data = producto;
            var config = {};

            $http.post('https://localhost:5001/api/product', data, config).then(successCallback, errorCallback);

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

