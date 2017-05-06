(function () {
    var controllerId = 'app.views.customfieldsetups.update';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.customeFieldSetup',
        function ($scope, $state, $stateParams, customfieldsetuptService) {
            var vm = this;
           
            vm.update = function () {
                if ($scope.customfieldsetupUpdateForm.$invalid) {
                    abp.notify.error(App.localize('Please Complete Required Field'));
                    return;
                }
                else {
                   
                    customfieldsetuptService.update(vm.customfieldsetup)

                        .success(function () {
                            abp.notify.success(App.localize('SavedSuccessfully'));
                            $state.go('customfieldsetup');

                        });
                }
            };



            function loadCustomFieldSetups() {
                customfieldsetuptService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.customfieldsetup = result;
                });
            };


            vm.back = function () {
                $state.go('customfieldsetup');
            };


            loadCustomFieldSetups();


        }
    ]);
})();