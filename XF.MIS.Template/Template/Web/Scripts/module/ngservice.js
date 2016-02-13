define(['angular', 'module/ngapp'], function (angular, app) {
    app.factory('service', [
        '$http', '$q', function ($http, $q) {
            return {
                query: function (config) {
                    var defer = $q.defer();
                    var param = {
                        method: config.method, 
                        url: config.url,
                        data: config.data
                    };
                    $http(param).success(function (data) {
                        defer.resolve(data);
                    }).error(function () {
                        defer.reject();
                    });
                    return defer.promise;
                }
            };
        }
    ]);
})