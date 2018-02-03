var route = function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.otherwise('/404');

    $stateProvider
        .state('index', {
            url: '',
            templateUrl: '/static/scripts/controller/WelcomeView.html',
            controller: WelcomeController
        })
        .state('welcome', {
            url: '/',
            templateUrl: '/static/scripts/controller/WelcomeView.html',
            controller: WelcomeController
        })
        .state('transforms', {
            url: '/transforms',
            templateUrl: '/static/scripts/controller/TransformItemsView.html',
            controller: TransformItemsController
        })
        .state('transformCreate', {
            url: '/create-transform',
            templateUrl: '/static/scripts/controller/TransformCreateView.html',
            controller: TransformCreateController
        })
        .state('templateCreate', {
            url: '/transform/:name/create-template',
            templateUrl: '/static/scripts/controller/TemplateCreateView.html',
            controller: TemplateCreateController
        })
        .state('transform', {
            url: '/transform/:name',
            templateUrl: '/static/scripts/controller/TransformSummaryView.html',
            controller: TransformSummaryController
        }
        )
        .state('404', {
            url: '/404',
            templateUrl: '/static/html/404.html'
        });
}