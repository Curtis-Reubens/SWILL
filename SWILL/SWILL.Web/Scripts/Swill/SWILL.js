var app = angular.module('swillApp', ['ngRoute']);

app.config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
    $routeProvider
        .when('/', { templateUrl: "partials/Home" })
        .when('/collection', { templateUrl: "partials/DinerCollection" })
        .otherwise({ redirectTo: '/' });

    //This makes our URLs nicer. Google it, and learn about fragment identifiers.
    $locationProvider.html5Mode(true);
}]);

app.service('signalRService', function ($rootScope) {
    var proxy = null;

    var initialize = function (connectionStartedCallback) {
        proxy = $.connection.swillHub;
        
        proxy.on('lunchCollected', function (lunch) {
            //Broadcasting this via the root scope means that any controllers in SWILL
            //can subscribe to this event via their own scopes and react appropriately
            $rootScope.$broadcast('lunchCollected', lunch);
        });

        $.connection.hub.start()
            .done(function () {
                console.log('Now connected, connection ID=' + $.connection.hub.id);
                connectionStartedCallback();
            })
            .fail(function (error) {
                console.log('Invocation of start failed. Error: ' + error);
            });
    };

    var getLunchDetails = function (success) {
        //At some point, we will allow the current date to be set via the URL
        //Where the date is not specified, this defaults to today.
        var currentDate = new Date();

        proxy.server.getLunchDetails(currentDate).done(function (response) {
            console.log('Invocation of GetLunchDetails succeeded');
            success(response);
        }).fail(function (error) {
            console.log('Invocation of GetLunchDetails failed. Error: ' + error);
        });
    };

    var markLunchAsCollected = function(dish, person) {
        proxy.server.markLunchAsCollected(dish, person).done(function () {
            console.log('Invocation of GetLunchDetails succeeded');
        }).fail(function (error) {
            console.log('Invocation of GetLunchDetails failed. Error: ' + error);
        });
    };

    //The object we return forms the public interface of this service.
    //If we add any other public methods to the service, we need to add them to the return object here.
    return {
        initialize: initialize,
        getLunchDetails: getLunchDetails,
        markLunchAsCollected: markLunchAsCollected
    };
});
