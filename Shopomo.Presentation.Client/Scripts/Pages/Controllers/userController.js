'use strict';

app.controller('userController', function ($scope, $http, $filter) {
    $scope.users = [];
    $scope.otpPassword = "";

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

    $scope.generateOTP = function (userId, index) {
        $http({
            method: 'POST',
            url: '/Login/GeneratePassword',
            data: { userId: userId }
        }).then(function success(response) {

            $scope.users[index].lastPassword = response.data;
            $scope.users[index].date = new Date();

            //$scope.otpPassword = response.data;
        }, function error(response) {
            console.log("erro");
        });
    }
});