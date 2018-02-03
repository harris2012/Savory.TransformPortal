function TransformService($resource, $q) {
    var resource = $resource('api/transform', {}, {
        items: {
            method: 'POST',
            isArray: true,
            url: 'api/transform/items'
        },
        count: {
            method: 'POST',
            url: 'api/transform/count'
        },
        item: {
            method: 'POST',
            url: 'api/transform/item?transformId=:transformId'
        },
        create: {
            method: 'POST',
            url: 'api/transform/create'
        }
    });

    return {
        items: function (pageIndex) {
            var d = $q.defer();
            resource.items({ pageIndex: pageIndex }, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        },
        count: function () {
            var d = $q.defer();
            resource.count({}, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        },
        item: function (transformId) {
            var d = $q.defer();
            resource.item({ transformId: transformId }, {}, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        },
        create: function (transform) {
            var d = $q.defer();
            resource.create({}, transform, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        }
    }
}