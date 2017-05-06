(function () {
    angular.module('app').controller('app.views.operations.createWorkCycleVideo', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.workCycleVideo', 'Upload',
        function ($rootScope, $scope, $modalInstance, workCycleVideoDetailService, Upload) {
            var vm = this;
            $scope.workcyclevideo = null;

            vm.save = function () {
                if ($scope.workCycleVideoCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    //  console.log(file);
                    $scope.workcyclevideo.operationPoolId = $rootScope.hId;
                    $scope.workcyclevideo.workCycleVideoPath = "app/theme/UI/images/Work_Cycle_Images/" + $scope.file.name;

                    if ($scope.workCycleVideoCreateForm.file.$valid && $scope.file) {
                        $scope.upload($scope.file);
                    }

                    workCycleVideoDetailService.createWorkCycleVideo($scope.workcyclevideo)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload',
                    data: { file: file }
                }).then(function (resp) {
                    console.log('Success ' + resp.config.data.file.name + 'uploaded. Response: ' + resp.data);
                }, function (resp) {
                    console.log('Error status: ' + resp.status);
                }, function (evt) {
                    var progressPercentage = parseInt(100.0 * evt.loaded / evt.total);
                    console.log('progress: ' + progressPercentage + '% ' + evt.config.data.file.name);
                });
            };

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();