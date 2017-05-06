(function () {
    var controllerId = 'app.views.operations.updateFolderTypes';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.folderDetail',
        function ($rootScope, $scope, $state, $stateParams, folderDetailService) {
            var vm = this;
            vm.operation = {};

            vm.update = function () {
                if ($scope.folderUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.operation.id = $stateParams.id;
                    vm.operation.operationPoolId = $rootScope.hId;
                    folderDetailService.updateFolderDetail(vm.operation)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('operation');

                        });
                }
            };


            function loadFolderDetails() {
                folderDetailService.getFolderDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.operation = result;

                });
            }

            vm.back = function () {
                $state.go('operation');
            };


            loadFolderDetails();

        }
    ]);
})();