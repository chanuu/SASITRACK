(function () {
    var controllerId = 'app.views.elements.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.element',
        function ($scope, $state, $stateParams, elementService) {
            var vm = this;

            function loadElements() {
                elementService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.element = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('elements');
            };

            loadElements();


        }
    ]);
})();