(function () {
    angular.module('app').controller('app.views.operations.createWorkCycleImage', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.workCycleImage', 'Upload', 
        function ($rootScope, $scope, $modalInstance, workCycleImageDetailService, Upload) {
            var vm = this;
            $scope.workcycleimage = null;

            vm.save = function () {
                if ($scope.workCycleImageCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                  
                    $scope.workcycleimage.operationPoolId = $rootScope.hId;
                    $scope.workcycleimage.workCycleImagePath = "app/theme/UI/images/Work_Cycle_Images/" + $scope.file.name;

                    if ($scope.workCycleImageCreateForm.file.$valid && $scope.file) {
                        $scope.upload($scope.file);
                    }
                                        
                    workCycleImageDetailService.createWorkCycleImage($scope.workcycleimage)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            $scope.upload = function (file) {
                Upload.upload({
                    url: '/api/upload',
                    data: { file: file, key: 2 }
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