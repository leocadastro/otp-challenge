app.controller('userController', function ($scope, $http, $window) {
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

    $scope.delete = function (userId) {

        if ($window.confirm('Are you sure?')) {
            $http({
                method: 'POST',
                url: '/User/Delete',
                data: { userId: userId }
            }).then(function success(response) {
                if (response.data == 1)
                    listUsers();
                else
                    console.log("erro ao remover");
            }, function error(response) {
                console.log("erro");
            });
        } 
    }

    listUsers();

});