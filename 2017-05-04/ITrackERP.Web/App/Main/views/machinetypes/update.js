(function () {
    var controllerId = 'app.views.machinetypes.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.machineType',
        function ($scope, $state, $stateParams, machinetypeService) {
            var vm = this;


            vm.update = function () {

                if ($scope.machineTypeUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    machinetypeService.update(vm.machinetype)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('machinetypes');

                        });
                }
            };


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