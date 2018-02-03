//Module
var module = angular.module('transform', ['ngResource', 'ui.router', 'ui.bootstrap']);

//Config
module.config(route);

//Service
module.service('TransformService', ['$resource', '$q', TransformService]);
module.service('TemplateService', ['$resource', '$q', TemplateService]);

// region Controllers
module.controller(WelcomeController);
module.controller(TransformItemsController);
module.controller(TransformCreateController);
module.controller(TemplateCreateController);
module.controller(TransformSummaryController);

