'use strict';

app.controller('loginController', function ($scope, $http) {
    $scope.form = {};

    $scope.submit = function () {
        console.log("teste");
        $http({
            method: 'POST',
            url: '/Login/Authenticate',
            data: { loginViewModel: $scope.form }
        }).then(function success(response) {
            if (response.data == true) {
                console.log("logou");
            }
            else {
                console.log("nao logou");
            }

        }, function error(response) {
            console.log("erro");
        });
    }
    
});