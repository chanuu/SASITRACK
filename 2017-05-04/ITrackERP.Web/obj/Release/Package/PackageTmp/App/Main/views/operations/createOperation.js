(function () {
    angular.module('app').controller('app.views.operations.createOperation', [
        '$scope', '$modalInstance', 'abp.services.app.operationPool', 'abp.services.app.machineType',
        function ($scope, $modalInstance, operationService, machinetypeService) {
            var vm = this;

            $scope.machinetypes = [];
            $scope.selectedMachineType = null;

            vm.save = function () {
                if ($scope.operationpoolCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.operation.machineType = $scope.selectedMachineType.machineTypeName;
                    operationService.create(vm.operation)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };

           
            function getMachineTypes() {
                machinetypeService.getMachineTypes({}).success(function (result) {

                    vm.machinetypes = result.items;
                });
            }
            getMachineTypes();

            //
            $scope.afterSelectedMachineTypes = function (selected) {
                if (selected) {
                    $scope.selectedMachineType = selected.originalObject;


                }


            }
            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();