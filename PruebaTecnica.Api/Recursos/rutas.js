(function () {

    const app = angular.module('pruebaTecnica', ["ngRoute", 'angularNotify']);

    app.config(function ($routeProvider, $httpProvider, $locationProvider) {

        $locationProvider.hashPrefix('');

        $routeProvider
            .when("/", {
                templateUrl: "/Index.html"
                , controller: "LayoutController"
            })
            .when("/ventas", {
                templateUrl: "/Paginas/Venta/Index.html"
                , controller: "VentaController"
            })

            
            /*
            .when("/Productos", {
                templateUrl: "./Paginas/Producto/Index.html"
                , controller: "ProductoController"
            })

            .when("/Productos/crear", {
                templateUrl: "./Paginas/Producto/Crear.html"
                , controller: "ProductoController"
            })*/




            .otherwise({
                redirectTo: "/"
            });

        $httpProvider.interceptors.push('AccessTokenHttpInterceptor');
    });

})();