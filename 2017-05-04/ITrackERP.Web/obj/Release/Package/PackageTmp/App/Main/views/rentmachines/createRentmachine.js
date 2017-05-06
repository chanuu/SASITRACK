(function () {
    angular.module('app').controller('app.views.rentmachines.createRentmachine', [
        '$scope', '$modalInstance', 'abp.services.app.rentMachine', 'abp.services.app.machineType',
        function ($scope, $modalInstance, rentmachineService, machinetypeService) {
            var vm = this;

            $scope.machinetypes = [];
            $scope.selectedMachineType = null;
        

            $scope.filter = {};
            $scope.dpOpenStatus = {};

            $scope.setDpOpenStatus = function (id) {
                $scope.dpOpenStatus[id] = true
            };

            $scope.fdate = new Date();
            $scope.tdate = new Date();


            vm.save = function () {
             
                if ($scope.rentmachineCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.rentmachine.fromDate = $scope.fdate;
                    vm.rentmachine.toDate = $scope.tdate;

                    vm.rentmachine.machineType = $scope.selectedMachineType.machineTypeName;
                    vm.rentmachine.status = "On-Rent";
                    rentmachineService.create(vm.rentmachine)
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