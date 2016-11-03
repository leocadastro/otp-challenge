'use strict';

app.controller('userController', function ($scope, $http) {
    $scope.users = [];

    var listUsers = function () {
        $http({
            method: 'GET',
            url: '/User/GetAll'
        }).then(function success(response) {
            $scope.users = response.data;
        }, function error(response) {
            console.log("erro");
        });
    }

    listUsers();
});