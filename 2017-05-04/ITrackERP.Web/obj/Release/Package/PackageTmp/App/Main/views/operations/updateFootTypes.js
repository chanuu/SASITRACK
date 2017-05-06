(function () {
    var controllerId = 'app.views.operations.updateFootTypes';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.footDetail',
        function ($rootScope, $scope, $state, $stateParams, footDetailService) {
            var vm = this;
            vm.footdetail = {};

            vm.update = function () {
                if ($scope.footUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.footdetail.id = $stateParams.id;
                    vm.footdetail.operationPoolId = $rootScope.hId;
                    footDetailService.updateFootDetail(vm.footdetail)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('operation');

                        });
                }
            };


            function loadFootDetails() {
                footDetailService.getFootDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.footdetail = result;

                });
            }

            vm.back = function () {
                $state.go('operation');
            };


            loadFootDetails();

        }
    ]);
})();