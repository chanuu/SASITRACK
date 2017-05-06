(function () {
    var controllerId = 'app.views.assets.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.asset',
        function ($scope, $state, $stateParams, assetService) {
            var vm = this;

            function loadAssets() {
                assetService.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.asset = result;
                });
            }


            vm.backToEventsPage = function () {
                $state.go('assets');
            };

            loadAssets();


        }
    ]);
})();