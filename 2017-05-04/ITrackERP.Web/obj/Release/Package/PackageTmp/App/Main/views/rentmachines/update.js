(function () {
    var controllerId = 'app.views.rentmachines.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.rentMachine', 'abp.services.app.machineType',
        function ($scope, $state, $stateParams, rentmachineService, machinetypeService) {
            var vm = this;
            $scope.selectedMachineType = null;

            vm.update = function () {
                if ($scope.rentmachineUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.rentmachine.machineType = $scope.selectedMachineType.machineTypeName;
                    rentmachineService.update(vm.rentmachine)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('rentmachines');

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



            function loadRentMachines() {
                rentmachineService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.rentmachine = result;
                    $scope.selectedMachineType = vm.rentmachine.machineType;

                    machinetypeService.getDetailByMachineType({
                        machineTypeName: vm.rentmachine.machineType
                    }).success(function (result) {
                        $scope.selectedMachineType = result;
                    });

                });
            }


            vm.backToEventsPage = function () {
                $state.go('rentmachines');
            };

            loadRentMachines();


        }
    ]);
})();