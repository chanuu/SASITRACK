(function () {
    angular.module('app').controller('app.views.operations.createFolderTypes', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.folderDetail',
        function ($rootScope, $scope, $modalInstance, folderDetailService) {
            var vm = this;
            $scope.folderdetail = null;

            vm.save = function () {
                if ($scope.folderTypeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.folderdetail.operationPoolId = $rootScope.hId;
                    folderDetailService.createFolderDetail($scope.folderdetail)
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