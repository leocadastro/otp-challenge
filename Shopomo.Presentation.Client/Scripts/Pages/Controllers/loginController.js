'use strict';

app.controller('loginController', function ($scope, $http, $location) {
    $scope.form = {};
    $scope.form.Email = $location.search().email;
    
    $scope.submit = function () {
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