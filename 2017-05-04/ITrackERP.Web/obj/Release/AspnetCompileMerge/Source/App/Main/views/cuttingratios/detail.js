(function () {
    var controllerId = 'app.views.cuttingratios.detail';
    angular.module('app').controller(controllerId, [
        '$scope', '$state', '$stateParams', 'abp.services.app.cuttingRatio',
        function ($scope, $state, $stateParams, ratioAppSerice) {
            var vm = this;
           

            function loadCuttingRatio() {
                ratioAppSerice.getDetail({
                    id: $stateParams.id
                }).success(function (result) {
                    vm.cuttingRatio = result;
                });
            }


            vm.back = function () {
                $state.go('workorders');
            };

            loadCuttingRatio();


        }
    ]);
})();