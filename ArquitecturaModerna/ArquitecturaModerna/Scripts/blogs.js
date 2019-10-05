'use strict';

var url = location.origin + '/api/blog';
(function () {
    angular
        .module("MyAPI", [])
        .controller("BlogController", ['$http', function ($http) {
            var $scope = this;
            $scope.blogs = [];

            $scope.CargaInicial = function () {
                $http({
                    url: url,
                    method: "GET",
                    headers: { Authorization: 'Basic U3VibmV0OjY3ODk=' },
                    data: {}
                }).then(function (response) {
                    console.log(response);
                    $scope.blogs = response.data;
                }, function (error) {
                    console.log(error);
                });
            };
        }]);
})();