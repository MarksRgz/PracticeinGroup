'use strict';

var url = location.origin + '/api/blog';
(function () {
    angular
        .module("MyAPI", [])
        .controller("BlogController", ['$http', function ($http) {
            var $scope = this;
            $scope.blogs = [];
            $scope.blog = {};

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

            $scope.AddBlog = function (blog) {
                if (blog.id_blog === undefined) {
                    console.log("Blog de Alta :", blog);
                    $http({
                        url: url,
                        method: "POST",
                        headers: { Authorization: 'Basic U3VibmV0OjY3ODk=' },
                        data: blog
                    }).then(function (response) {
                        console.log(response);
                        $scope.blogs.push(response.data);
                        $scope.blog = {};
                        $('#exampleModal').modal('hide');
                        $('#btnDelete').hide();
                    }, function (error) {
                        console.log(error);
                    });
                } else {

                    console.log("Blog a Editar:", blog);
                    $http({
                        url: url + '?idp=' + blog.id_blog,
                        method: "PUT",
                        headers: { Authorization: 'Basic U3VibmV0OjY3ODk=' },
                        data: blog
                    }).then(function (response) {
                        console.log(response);
                        $scope.blog = {};
                        $('#exampleModal').modal('hide');
                        $('#btnDelete').show();
                    }, function (error) {
                        console.log(error);
                    });
                }

            };
            $scope.DeleteBlog = function (blog) {
                if (blog.id_blog !== '') {
                    console.log('Blog a eliminar');
                    $http({
                        url: url + '?idp=' + blog.id_blog,
                        method: "DELETE",
                        headers: { Authorization: 'Basic U3VibmV0OjY3ODk=' },
                        data: blog
                    }).then(function (response) {
                        console.log(response);
                        $scope.blog = {};
                        $('#exampleModal').modal('hide');
                    }, function (error) {
                        console.log(error);
                    });
                }

            }

            $scope.OpenModalEdit = function (blog) {
                $('#exampleModal').modal('show');
                $scope.blog = blog;
            };

            $scope.ClearModal = function () {
                $scope.blog = {};
            };
        }]);
})();