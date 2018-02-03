function TemplateService($resource, $q) {
    var resource = $resource('api/transform', {}, {
        items: {
            method: 'POST',
            isArray: true,
            url: 'api/template/items?name=:name'
        },
        item: {
            method: 'POST',
            url: 'api/template/item?name=:name&version=:version'
        },
        create: {
            method: 'POST',
            url: '/api/template/create'
        },
        preview: {
            method: 'POST',
            url: '/api/template/preview'
        }
    });

    return {
        items: function (name) {
            var d = $q.defer();
            resource.items({ name: name }, {}, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        },
        item: function (name, version) {
            var d = $q.defer();
            resource.item({ transformId: transformId, version: version }, {}, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        },
        create: function (template) {
            var d = $q.defer();
            resource.create({}, template, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        },
        preview: function (template) {
            var d = $q.defer();
            resource.preview({}, template, function (result) {
                d.resolve(result);
            }, function (result) {
                d.reject(result);
            });
            return d.promise;
        }
    }
}