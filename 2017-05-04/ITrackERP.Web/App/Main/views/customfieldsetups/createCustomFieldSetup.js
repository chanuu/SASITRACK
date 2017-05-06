(function () {
    angular.module('app').controller('app.views.customfieldsetups.createCustomFieldSetup', [
        '$scope', '$modalInstance', 'abp.services.app.customeFieldSetup',
        function ($scope, $modalInstance, customfieldsetuptService) {
            var vm = this;

            vm.customfieldsetup = {};
            vm.save = function () {

                if ($scope.customfieldsetupCreateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                    customfieldsetuptService.create(vm.customfieldsetup)
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