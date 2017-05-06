(function () {
    var controllerId = 'app.views.operations.updateAttatchmentTypes';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.attatchmentDetail',
        function ($rootScope, $scope, $state, $stateParams, attatchmentDetailService) {
            var vm = this;
            vm.attatchmentdetail = {};

            vm.update = function () {
                if ($scope.attatchmentUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.attatchmentdetail.id = $stateParams.id;
                    vm.attatchmentdetail.operationPoolId = $rootScope.hId;
                    attatchmentDetailService.updateAttatchmentDetail(vm.attatchmentdetail)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('operation');

                        });
                }
            };


            function loadAttatchmentDetails() {
                attatchmentDetailService.getAttatchmentDetailsByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.attatchmentdetail = result;

                });
            }

            vm.back = function () {
                $state.go('operation');
            };


            loadAttatchmentDetails();

        }
    ]);
})();