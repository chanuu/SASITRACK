(function () {
    angular.module('app').controller('app.views.operations.createFootTypes', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.footDetail',
        function ($rootScope, $scope, $modalInstance, footDetailService) {
            var vm = this;
            $scope.footdetail = null;

            vm.save = function () {
                if ($scope.footTypeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.footdetail.operationPoolId = $rootScope.hId;
                    footDetailService.createFootDetail($scope.footdetail)
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