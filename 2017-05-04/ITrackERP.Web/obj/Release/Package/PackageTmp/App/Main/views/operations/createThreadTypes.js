(function () {
    angular.module('app').controller('app.views.operations.createThreadTypes', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.threadDetail',
        function ($rootScope, $scope, $modalInstance, threadDetailService) {
            var vm = this;
            $scope.threaddetail = null;

            vm.save = function () {
                if ($scope.threadTypeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.threaddetail.operationPoolId = $rootScope.hId;
                    threadDetailService.createThreadDetail($scope.threaddetail)
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