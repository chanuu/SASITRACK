(function () {
    var controllerId = 'app.views.operations.updateNeedleTypes';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.needleDetail',
        function ($rootScope, $scope, $state, $stateParams, needleDetailService) {
            var vm = this;
            vm.needledetail = {};

            vm.update = function () {
                if ($scope.needleUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.needledetail.id = $stateParams.id;
                    vm.needledetail.operationPoolId = $rootScope.hId;
                    needleDetailService.updateNeedleDetail(vm.needledetail)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('operation');

                        });
                }
            };


            function loadNeedleDetails() {
                needleDetailService.getNeedleDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.needledetail = result;

                });
            }

            vm.back = function () {
                $state.go('operation');
            };


            loadNeedleDetails();

        }
    ]);
})();