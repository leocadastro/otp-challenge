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
                toastr.success('Authenticated with success', 'Congratulations!')
                $scope.form = {};
            }
            else {
                toastr.error('Email or Password is not valid.', 'Problem on Login!')
            }

        }, function error(response) {
            console.log("erro");
        });
    }
    
});