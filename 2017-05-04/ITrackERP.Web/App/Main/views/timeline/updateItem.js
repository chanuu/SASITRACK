(function () {
    var controllerId = 'app.views.timeline.updateItem';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$modalInstance', '$stateParams', 'abp.services.app.machineRequirement', 'abp.services.app.machineType',
        function ($rootScope, $scope, $state, $modalInstance, $stateParams, machinerequirementService, machinetypeService) {
            var vm = this;
            vm.machinerequirement = {};

            $scope.machinetypes = [];
            $scope.selectedMachineType = null;


            vm.update = function () {
                if ($scope.machineRequirementItemUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    vm.machinerequirement.machineType = $scope.selectedMachineType.machineTypeName;
                    vm.machinerequirement.id = $rootScope.itemId;
                    vm.machinerequirement.machineRequirementId = $rootScope.machineRequirementId

                    machinerequirementService.updateItem(vm.machinerequirement)

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

            
            function loadMachineRequirements() {
                machinerequirementService.getMachineRequirementItemByID({
                    id: $rootScope.itemId
                }).success(function (result) {
                    vm.machinerequirement = result;

                    machinetypeService.getDetailByMachineType({
                        machineTypeName: vm.machinerequirement.machineType
                    }).success(function (result) {
                        $scope.selectedMachineType = result;
                    });


                });
            }

            vm.cancel = function () {
                $modalInstance.close();
            };

            loadMachineRequirements();

        }
    ]);
})();