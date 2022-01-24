var app = angular.module("StudnetApp", []);

app.config(function ($provide) {

    $provide.decorator('$exceptionHandler', function ($delegate) {

        return function (exception, cause) {
            $delegate(exception, cause);
          //  alert(exception.message.reason);
           // alert(cause);

            alert('Error occurred! Please contact admin.');
        };
    });
});


//app.config(function ($provide) {

//    $provide.decorator("$exceptionHandler", function ($delegate, $injector) {
//        return function (exception, cause) {
//            var $rootScope = $injector.get("$rootScope");
//            $rootScope.addError({ message: "Exception", reason: exception });
//            $delegate(exception, cause);
//        };
//    });

//});