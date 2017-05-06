(function () {
    angular.module('app').controller('app.views.machinetypes.createMachinetype', [
        '$scope', '$modalInstance', 'abp.services.app.machineType',
        function ($scope, $modalInstance, machinetypeService) {
            var vm = this;



            vm.save = function () {

                if ($scope.machinetypeCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {

                    machinetypeService.create(vm.machinetype)
                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $modalInstance.close();

                        });
                }
            };



            vm.cancel = function () {
                $modalInstance.close();
            };

        }
    ]);
})();