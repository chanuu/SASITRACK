(function () {
    var controllerId = 'app.views.customfieldsetups.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.customeFieldSetup',
        function ($scope, $state, $stateParams, customfieldsetuptService) {
            var vm = this;

            function loadCustomFieldSetups() {
                customfieldsetuptService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.customfieldsetup = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('customfieldsetup');
            };

            loadCustomFieldSetups();


        }
    ]);
})();