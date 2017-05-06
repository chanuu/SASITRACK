(function () {
    var controllerId = 'app.views.rentmachines.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.rentMachine',
        function ($scope, $state, $stateParams, rentmachineService) {
            var vm = this;

            function loadRentMachines() {
                rentmachineService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.rentmachine = result;
                });
            }

            vm.updateStatus = function () {
                rentmachineService.updateStatus({
                    id: $stateParams.id
                }).success(function (result) {
                    abp.notify.success(App.localize('UpdateSuccessfully'));
                    $state.go('rentmachines');
                });
            }
            vm.backToEventsPage = function () {
                $state.go('rentmachines');
            };

            loadRentMachines();


        }
    ]);
})();