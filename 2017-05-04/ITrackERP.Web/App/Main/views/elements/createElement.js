(function () {
    angular.module('app').controller('app.views.elements.createElement', [
        '$scope', '$modalInstance', 'abp.services.app.element', 'Upload', '$http',
        function ($scope, $modalInstance, elementService, Upload, $http) {
            var vm = this;

            vm.save = function () {

                if ($scope.elementCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    if ($scope.file != null)
                    {
                        vm.element.path = "app/theme/UI/images/Elements/" + $scope.file.name;
                    }
                    else {
                        vm.element.path = "N/A";
                    }

                    if ($scope.elementCreateForm.file.$valid && $scope.file) {
                        $scope.upload($scope.file);
                    }

                    elementService.create(vm.element)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };

            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload/',
                    data: { file: file, key: 4 }
                }).then(function (resp) {
                    // console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    // console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    //  console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            };
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();