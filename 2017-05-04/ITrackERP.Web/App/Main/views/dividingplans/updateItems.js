(function () {
    var controllerId = 'app.views.dividingplans.updateItems';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.dividingPlanHeader', 'abp.services.app.operationPool',
        function ($rootScope, $scope, $state, $stateParams, dividingplanService, operationpoolService) {
            var vm = this;
            vm.dividingplan = {};

            $scope.operations = [];
            $scope.selectedOperationCode = null;

            vm.update = function () {
                if ($scope.dividingPlanHeaderItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                vm.dividingplan.id = $stateParams.id;
                vm.dividingplan.dividingPlanHeaderId = $rootScope.hId;
                vm.dividingplan.operationNo = $scope.selectedOperationCode.operationCode;
                dividingplanService.updateItem(vm.dividingplan)

                    .success(function () {
                        abp.notify.success(App.localize('SavedSuccessfully'));
                        $state.go('dividingplan');

                    });
            }
            };


            $scope.getOperationFieldsEvent = function (key) {
                vm.dividingplan.operationName = $scope.selectedOperationCode.operationName;
                vm.dividingplan.smvType = $scope.selectedOperationCode.smvType;
                vm.dividingplan.machineType = $scope.selectedOperationCode.machineType;
                vm.dividingplan.operationRole = $scope.selectedOperationCode.operationRole;
                vm.dividingplan.partName = $scope.selectedOperationCode.partName;
                vm.dividingplan.smv = $scope.selectedOperationCode.smv;
            }


            
            function loadDividingPlanHeaders() {
                dividingplanService.getDividingPlanHeaderItemByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.dividingplan = result;
                    
                    operationpoolService.getDetailByOperationCode({
                        operationCode: vm.dividingplan.operationNo
                    }).success(function (result) {
                        $scope.selectedOperationCode = result;
                    });



                });
            }

            vm.back = function () {
                $state.go('dividingplan');
            };


            loadDividingPlanHeaders();

            function getOperations() {
                operationpoolService.getOperations({}).success(function (result) {
                    vm.operations = result.items;
                });
            }
            getOperations();

            //
            $scope.afterSelectedOperationCodes = function (selected) {
                if (selected) {
                    $scope.selectedOperationCode = selected.originalObject;
                }

            }

        }
    ]);
})();