(function () {
    angular.module('app').controller('app.views.machinerequirements.createItems', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.machineRequirement','abp.services.app.machineType',
        function ($rootScope, $scope, $modalInstance, machinerequirementService, machinetypeService) {
            var vm = this;
            $scope.machinerequirementitem = null;

            $scope.machinetypes = [];
            $scope.selectedMachineType = null;

            vm.save = function () {
                if ($scope.machineRequirementItemCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    $scope.machinerequirementitem.machineType = $scope.selectedMachineType.machineTypeName;
                    $scope.machinerequirementitem.machineRequirementId = $rootScope.wId;

                    machinerequirementService.createItem($scope.machinerequirementitem)
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