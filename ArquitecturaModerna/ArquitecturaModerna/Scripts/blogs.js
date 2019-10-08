'use strict';

var url = location.origin + '/api/blog';
(function () {
    angular
        .module("MyAPI", ["ngFileUpload"])
        .controller("BlogController", ['$http', 'Upload', function ($http, Upload) {
            var $scope = this;
            $scope.blogs = [];
            $scope.blog = {};
            $scope.files = {};

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
                    console.log("Blog de Alta :");
                    blog.img_blog = 'img/' + $scope.files[0].name;
                    Upload.upload({
                        url: '/api/blog',
                        data: { file: $scope.files }
                    }).then(function (response) {
                        $http({
                            url: url + "/new",
                            method: "POST",
                            headers: { 'Authorization': 'Basic U3VibmV0OjY3ODk=', 'ContentType': 'application/json' },
                            data: blog
                        }).then(function (response) {
                            console.log(response);
                            $scope.blogs.push(response.data.newBlog);
                            $scope.blog = {};
                            $('#exampleModal').modal('hide');
                            $('#btnDelete').hide();
                        }, function (error) {
                            console.log(error);
                        });
                    }, function (err) {
                        console.log("Error status: " + err.status);
                        console.log("Error de foto: ", err);
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
                        $scope.blogs = $scope.blogs.filter(f => f.id_blog !== blog.id_blog);
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