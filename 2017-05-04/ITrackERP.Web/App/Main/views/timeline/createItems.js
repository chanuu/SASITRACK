(function () {
    angular.module('app').controller('app.views.timeline.createItems', ['$rootScope',
        '$scope', '$modalInstance', 'abp.services.app.machineRequirement', 'abp.services.app.machineType',
        function ($rootScope, $scope, $modalInstance, machineRequirementService, machinetypeService) {
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
                    $scope.machinerequirementitem.machineRequirementId = $rootScope.machineRequirementId;

                    machineRequirementService.createItem($scope.machinerequirementitem)
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

            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();