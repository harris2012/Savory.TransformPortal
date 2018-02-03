function TransformSummaryController($scope, $stateParams, TransformService, TemplateService) {

    $scope.init = function () {

        var name = $stateParams.name;

        $scope.name = name;

        //基本信息
        TransformService.item(name).then(function (response) {

            $scope.transform = response;
        });

        //版本列表
        TemplateService.items(name).then(function (response) {

            $scope.templateList = response;
        })
    }

    $scope.beginEdit = function () {

        $scope.isEditing = true;

        $('#viewTemplateDom').hide();
        $('#editTemplateDomContainer').show();

        if ($scope.thisEditor == null) {
            $scope.thisEditor = CodeMirror.fromTextArea(document.getElementById('templateDOM'), {
                styleActiveLine: true,
                lineNumbers: true,
                lineWrapping: true,
                smartIndent: false
            });
            $scope.thisEditor.setSize('auto', 'auto');
        }
        $scope.thisEditor.setValue($scope.transform.template);
    }

    $scope.saveEdit = function () {

        $scope.isEditing = false;

        $('#viewTemplateDom').show();
        $('#editTemplateDomContainer').hide();
    }

    $scope.cancelEdit = function () {

        $scope.isEditing = false;

        $('#viewTemplateDom').show();
        $('#editTemplateDomContainer').hide();
    }

    $scope.init();
}