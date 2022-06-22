(function () {

    var app = angular.module('pruebaTecnica');

    app.controller("AutenticacionController", function ($scope, $window, $location, AutenticacionService) {

        $scope.credenciales = {};
        $scope.enableLogin = true;
        $scope.getUsuarioLogeado = {};


        $scope.login = function (credenciales) {

            var respuesta = AutenticacionService.getAutenticacionPorCrendenciales(credenciales);
            

            respuesta.then(function (response) {

                const resp = response.data;

                

                debugger;

                if(resp.data && resp.data.code != null){
                //Success
                    const re = JSON.stringify(resp.data);
                    $window.localStorage['user'] = re;
                    alert("¡Bienvenido!");
                    setTimeout(function () { window.location.href = './';}, 2000);   
                }

                
            }, function (response) {
                alert("Usuario y/o contraseña incorrectos");
            });
        };

    });

    app.factory('AccessTokenHttpInterceptor', function ($window, $q) {

        return {
            //Para cada petición, se usa el encabezado token
            request: function ($config) {

                if ($window.localStorage['code'] != null)
                {
                    //Obtengo el token de la cookie
                    var code = $window.localStorage['code'];
                    // autorizo el token
                    $config.headers['Authorization'] = code;
                }

                return $config;
            },
            response: function (response) {
                return response;
            },
            responseError: function (response) {
                return $q.reject(response);
            }
        };
    });

    app.service('AutenticacionService', function ($http, $q, $window) {

        this.getAutenticacionPorCrendenciales = function (credenciales) {

            var response = $q.defer();
            
            var data = {
                userName: credenciales.username
                , password: credenciales.password
                , grant_type: 'password'
            };

            var config = {
                headers: {
                    'Content-Type': 'application/x-www-form-urlencoded'
                }
            };

            $http.post('https://localhost:5001/api/security/login?userName=' + credenciales.username + '&password=' + credenciales.password).then(successCallback, errorCallback);

            function successCallback(e) {

                if (e == undefined) {

                    resultado = {
                        error: true
                        , mensaje: "Usuario o contraseña incorrectos."
                        , data: null
                    }

                    response.reject(resultado);
                }
                else {
                    var resultado = {
                        error: false
                        , mensaje: ""
                        , data: e.data
                    }

                    response.resolve(resultado);
                }

            };

            function errorCallback(e) {

                var resultado = {};

                if (e = !undefined) {

                    resultado = {
                        error: true
                        , mensaje: "Usuario o contraseña incorrectos."
                        , data: e.data
                    }
                }

                response.reject(resultado);
            };

            return response.promise;
        };


        this.logout = function () {
            localStorage.clear();
        };

    });

})();