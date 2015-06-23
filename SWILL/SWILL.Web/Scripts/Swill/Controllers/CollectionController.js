var app = angular.module('swillApp');

app.controller('collectionController', ['$scope', 'signalRService', function ($scope, signalRService) {
    var service = signalRService;

    service.initialize(function () {
        service.getLunchDetails(function (result) {
            $scope.$apply(function() {
                $scope.lunch = result;
            });
        });
    });

    $scope.markCollected = function(dish, person) {
        service.markLunchAsCollected(dish, person);
    };

    //This logic can be replaced later when every order has a unique ID.
    //Note the use of the library "Lodash" here (accessed via the "_" character).
    //Lodash has lots of really useful Javascript functions and is documented here: http://lodash.com
    $scope.$on('lunchCollected', function (e, collected) {
        //Find the dish which for the collected order.
        var dish = _.find($scope.lunch.dishes, function (item) { return item.name === collected.dish; });
        if (dish === null) return;

        //Find the specific order by looking up the user's name.
        var order = _.find(dish.orders, function (item) { return item.name === collected.person; });
        if (order === null) return;

        //Remember that the lunchCollected event can be triggered at any time.
        //We need to set order.collected inside a $scope.$apply to make the screen update.
        $scope.$apply(function() {
            order.collected = true;
        });
    });
}]);