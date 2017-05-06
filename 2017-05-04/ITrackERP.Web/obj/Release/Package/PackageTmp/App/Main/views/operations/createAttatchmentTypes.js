(function () {
    angular.module('app').controller('app.views.operations.createAttatchmentTypes', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.attatchmentDetail',
        function ($rootScope, $scope, $modalInstance, attatchmentDetailService) {
            var vm = this;
            $scope.attatchmentdetail = null;

            vm.save = function () {
                if ($scope.attatchmentTypeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.attatchmentdetail.operationPoolId = $rootScope.hId;
                    attatchmentDetailService.createAttatchmentDetail($scope.attatchmentdetail)
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