var app = angular.module('swillApp');
app.controller('collectionController', ['$scope', function($scope) {
    $scope.dish = {
        name: 'Slow-Roast Lamb',
        description: 'Tasty noms.'
    };
}]);