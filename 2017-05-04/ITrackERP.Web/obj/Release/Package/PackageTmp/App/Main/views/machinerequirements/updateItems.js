(function () {
    var controllerId = 'app.views.machinerequirements.updateItems';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$state', '$stateParams', 'abp.services.app.machineRequirement', 'abp.services.app.machineType',
        function ($rootScope, $scope, $state, $stateParams, machinerequirementService, machinetypeService) {
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

                    vm.machinerequirement.id = $stateParams.id;
                    vm.machinerequirement.machineRequirementId = $rootScope.wId;

                    vm.machinerequirement.fromDate = $scope.fdate;
                    vm.machinerequirement.toDate = $scope.tdate;

                    machinerequirementService.updateItem(vm.machinerequirement)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('machinerequirement');

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

            function loadMachineRequirements() {
                machinerequirementService.getMachineRequirementItemByID({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.machinerequirement = result;

                    machinetypeService.getDetailByMachineType({
                        machineTypeName: vm.machinerequirement.machineType
                    }).success(function (result) {
                        $scope.selectedMachineType = result;
                    });


                });
            }

            vm.back = function () {
                $state.go('machinerequirement');
            };


            loadMachineRequirements();

        }
    ]);
})();