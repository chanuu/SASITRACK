(function () {
    angular.module('app').controller('app.views.operations.createNeedleTypes', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.needleDetail',
        function ($rootScope, $scope, $modalInstance, needleDetailService) {
            var vm = this;
            $scope.needledetail = null;

            vm.save = function () {
                if ($scope.needleTypeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.needledetail.operationPoolId = $rootScope.hId;
                    needleDetailService.createNeedleDetail($scope.needledetail)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };




            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();