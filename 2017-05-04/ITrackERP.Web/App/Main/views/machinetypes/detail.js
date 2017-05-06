(function () {
    var controllerId = 'app.views.machinetypes.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.machineType',
        function ($scope, $state, $stateParams, machinetypeService) {
            var vm = this;

            function loadMachineTypes() {
                machinetypeService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.machinetype = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('machinetypes');
            };

            loadMachineTypes();


        }
    ]);
})();