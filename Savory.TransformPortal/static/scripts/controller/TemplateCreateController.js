function TemplateCreateController($scope, $stateParams, TransformService, TemplateService) {

    $scope.init = function () {

        //正文
        $scope.bodyEditor = CodeMirror.fromTextArea(document.getElementById('bodyDom'), {
            styleActiveLine: true,
            lineNumbers: true,
            lineWrapping: true,
            smartIndent: false
        });
        $scope.bodyEditor.setSize('auto', 'auto');

        //扩展类
        $scope.extensionEditor = CodeMirror.fromTextArea(document.getElementById('extensionDom'), {
            styleActiveLine: true,
            lineNumbers: true,
            lineWrapping: true,
            smartIndent: false
        });
        $scope.extensionEditor.setSize('auto', 'auto');

        //示例json
        $scope.itemJsonValueEditor = CodeMirror.fromTextArea(document.getElementById('itemJsonValueDom'), {
            styleActiveLine: true,
            lineNumbers: true,
            lineWrapping: true,
            smartIndent: false
        });
        $scope.itemJsonValueEditor.setSize('auto', 'auto');

        //预览
        $scope.previewEditor = CodeMirror.fromTextArea(document.getElementById('previewDom'), {
            styleActiveLine: true,
            lineNumbers: true,
            lineWrapping: true,
            smartIndent: false
        });
        $scope.previewEditor.setSize('auto', 'auto');

        //基本信息
        TransformService.item($stateParams.name).then(function (response) {

            if (response.name != null) {

                $scope.transform = response;

                $scope.template = { name: response.name };
            }
        });
    }

    $scope.init();

    $scope.confirmCreateTemplate = function () {

        //正文
        $scope.bodyErrorMessage = null;
        var body = $scope.bodyEditor.getValue();
        if (body == null || body.length == 0) {
            $scope.bodyErrorMessage = "请填写正文";
            return;
        }
        $scope.template.body = body;

        //扩展类
        $scope.extensionErrorMessage = null;
        var extension = $scope.extensionEditor.getValue();
        if (extension == null || extension.length == 0) {
            $scope.extensionErrorMessage = "请填写扩展类";
            return;
        }
        $scope.template.extension = extension;

        //示例Json
        $scope.itemJsonValueErrorMessage = null;
        var itemJsonValue = $scope.itemJsonValueEditor.getValue();
        if (itemJsonValue == null || itemJsonValue.length == 0) {
            $scope.itemJsonValueErrorMessage = "请填写示例json";
            return;
        }
        $scope.template.itemJsonValue = itemJsonValue;

        $scope.waiting = true;
        $scope.message = null;

        TemplateService.create($scope.template).then(function (response) {

            $scope.waiting = false;

            $scope.message = response.message;
        })
    }

    //预览
    $scope.previewTemplate = function () {

        //正文
        $scope.bodyErrorMessage = null;
        var body = $scope.bodyEditor.getValue();
        if (body == null || body.length == 0) {
            $scope.bodyErrorMessage = "请填写正文";
            return;
        }
        $scope.template.body = body;

        //扩展类
        $scope.extensionErrorMessage = null;
        var extension = $scope.extensionEditor.getValue();
        if (extension == null || extension.length == 0) {
            $scope.extensionErrorMessage = "请填写扩展类";
            return;
        }
        $scope.template.extension = extension;

        //示例Json
        $scope.itemJsonValueErrorMessage = null;
        var itemJsonValue = $scope.itemJsonValueEditor.getValue();
        if (itemJsonValue == null || itemJsonValue.length == 0) {
            $scope.itemJsonValueErrorMessage = "请填写示例json";
            return;
        }
        $scope.template.itemJsonValue = itemJsonValue;

        $scope.waiting = true;
        $scope.preview = null;

        TemplateService.preview($scope.template).then(function (response) {

            $scope.waiting = false;

            $scope.previewEditor.setValue(response.data);
        })
    }
}