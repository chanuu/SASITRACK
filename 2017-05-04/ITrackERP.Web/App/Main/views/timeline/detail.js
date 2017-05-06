(function () {
    var controllerId = 'app.views.timeline.detail';
    angular.module('app').controller(controllerId, ['$rootScope',
        '$scope', '$modal', '$modalInstance', '$state', '$stateParams', 'abp.services.app.machineRequirement',
        function ($rootScope, $scope, $modal, $modalInstance, $state, $stateParams, machinerequirementService) {
            var vm = this;

            function loadMachineRequirementItems() {
                machinerequirementService.getMachineRequirementItemByID({
                    id: $rootScope.itemId
                }).success(function (result) {
                    vm.machinerequirement = result;
                });
            }


            vm.cancel = function () {
                $modalInstance.close();
            };

            loadMachineRequirementItems();

        }
    ]);
})();