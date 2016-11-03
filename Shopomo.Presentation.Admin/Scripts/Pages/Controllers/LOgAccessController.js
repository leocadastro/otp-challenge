app.controller('logAccessController', function ($scope, $http, $window) {
    $scope.logs = [];

    var listLogs = function () {
        $http({
            method: 'GET',
            url: '/LogAccess/GetAll'
        }).then(function success(response) {
            $scope.logs = response.data;
        }, function error(response) {
            console.log("erro");
        });
    }

    listLogs();

});