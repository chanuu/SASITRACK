(function () {
    var controllerId = 'app.views.operations.updateThreadTypes';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.threadDetail',
        function ($rootScope, $scope, $state, $stateParams, threadDetailService) {
            var vm = this;
            vm.threaddetail = {};

            vm.update = function () {
                if ($scope.threadUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.threaddetail.id = $stateParams.id;
                    vm.threaddetail.operationPoolId = $rootScope.hId;
                    threadDetailService.updateThreadDetail(vm.threaddetail)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('operation');

                        });
                }
            };


            function loadThreadDetails() {
                threadDetailService.getThreadDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.threaddetail = result;

                });
            }

            vm.back = function () {
                $state.go('operation');
            };


            loadThreadDetails();

        }
    ]);
})();